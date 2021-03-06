﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement: MonoBehaviour {

    [Range(1, 5)]
    public float speed = 1.0f;

    private Rigidbody2D rgb;
    private float input_x;
    private float input_y;
    private Vector2 movement;
    private PlayerAnimManager anim;


    [HideInInspector]
    public GameGlobals.PlayerState currentState;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimManager>();
      
    }


    void Update()
    {
        Movement();
        OpenCloseMenuPanel();
    }


    void FixedUpdate()
    {
        rgb.velocity = movement;
        Interact();
    }


    void Movement()
    {
        if (CanMove())
        {
            input_x = Input.GetAxisRaw("Horizontal");
            input_y = Input.GetAxisRaw("Vertical");

            movement = new Vector2(input_x, input_y) * speed;

           anim.Estado_Correr_Parado(rgb.velocity, movement);
        }
    }

    public void OpenCloseMenuPanel()
    {
        if (CanUseMenu())
            if (Input.GetKeyDown(KeyCode.Escape) && UIManager.Instance.isEmpty())
            {
                StateInMenu();
                Time.timeScale = 0;
                UIManager.Instance.CreateMenuPanel();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.Instance.Pop();
                if (UIManager.Instance.isEmpty())
                {
                    Time.timeScale = 1;
                    StateIdle();
                }
            }
    }

    public IEnumerator MoveToPosition(GameObject point)
    {
        while (Vector2.Distance(transform.position,point.transform.position) > 0.1)
        {
            Vector2 newDirection = new Vector2(point.transform.position.x - rgb.position.x,
                                                point.transform.position.y - rgb.position.y);

            rgb.position = Vector2.MoveTowards(rgb.position, point.transform.position, Time.deltaTime * 1);

            anim.Estado_Caminar_Parado(newDirection);
            yield return null;
        }
        anim.Estado_Caminar_Parado(Vector2.zero);
        
        yield return null;
    }

    void Interact()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && currentState != GameGlobals.PlayerState.Interacting)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 1.0f, 1 << GameGlobals.LayerInteractable);
            //Si hay algo interactable empezamos la corrutina
            if (hit)
            {
                StartCoroutine(Interact_Coroutine(hit));
            }
        }
    }

    IEnumerator Interact_Coroutine(RaycastHit2D hit)
    {
        StateInteracting();
        var interactable = hit.collider.GetComponent<Interactable>();
        yield return interactable.Interact();
        StateIdle();
    }
    
    public void StateInteracting()
    {
        currentState = GameGlobals.PlayerState.Interacting;
        StopMovement();
    }

    public void StateFighting()
    {
        currentState = GameGlobals.PlayerState.Fighting;
        StopMovement();
    }

    public void StateIdle()
    {
        currentState = GameGlobals.PlayerState.Idle;
    }
    public void StopMovement()
    {
        rgb.velocity = new Vector2(0, 0);
        movement = new Vector2(0, 0);
        anim.Estado_Correr_Parado(rgb.velocity, movement);
    }

    public void StateInMenu()
    {
        currentState = GameGlobals.PlayerState.Menu;
    }


    public bool CanUseMenu()
    {
        return (!currentState.Equals(GameGlobals.PlayerState.Interacting) && !currentState.Equals(GameGlobals.PlayerState.Fighting));
    }

    public bool CanMove()
    {
        return (currentState.Equals(GameGlobals.PlayerState.Idle));
    }

    public bool isInteracting()
    {
        if (currentState.Equals(GameGlobals.PlayerState.Interacting))
            return true;
        return false;
    }

    public IEnumerator WaitForStartFight()
    {
        while (!currentState.Equals(GameGlobals.PlayerState.Fighting))
            yield return null;
        yield return null;
    }

    public IEnumerator WaitForFinishFight()
    {
        while (currentState.Equals(GameGlobals.PlayerState.Fighting))
            yield return null;
        yield return null;
    }

}
