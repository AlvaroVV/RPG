using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement: MonoBehaviour {

    [Range(1, 5)]
    public float speed = 1.0f;

    private Rigidbody2D rgb;
    private float input_x;
    private float input_y;
    private Vector2 movement;
    private PlayerAnimHandler anim;

    [HideInInspector]
    public GameGlobals.PlayerState currentState;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimHandler>();
    }

    void Start()
    {
        //Cuando cargamos el personaje le preguntamos al GameSlot donde se guardó la última vez
        transform.position = new Vector3(GameSlotInfo.currentGameSlot.playerPositionX, GameSlotInfo.currentGameSlot.playerPositionY, 0);
        //anim.Estado_Sleeping();
    }


    void Update()
    {
        Movement();
    }


    void FixedUpdate()
    {
        rgb.velocity = movement;
        Interact();
    }


    void Movement()
    {
        if (currentState != GameGlobals.PlayerState.Interacting)
        {
            input_x = Input.GetAxisRaw("Horizontal");
            input_y = Input.GetAxisRaw("Vertical");

            movement = new Vector2(input_x, input_y) * speed;

           anim.Estado_Correr_Parado(rgb.velocity, movement);
        }
    }

    void Interact()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && currentState != GameGlobals.PlayerState.Interacting)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 0.7f, 1 << GameGlobals.LayerInteractable);
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
}
