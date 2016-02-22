using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    [Range(1, 5)]
    public float speed = 1.0f;

    private Rigidbody2D rgb;
    private float input_x;
    private float input_y;
    private Vector2 movement;
    private enum PlayerState
    {
        Running,
        Interacting,
    }

    private PlayerState state;
    private Animator anim;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerAnimHandler.Animator = anim;
    }

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(input_x, input_y) * speed;

    }


    void FixedUpdate()
    {
        Movement();
        StartCoroutine(Interact());
    }


    void Movement()
    {
        if (state != PlayerState.Interacting)
        {
            rgb.MovePosition(rgb.position + movement * Time.fixedDeltaTime);
            PlayerAnimHandler.Estado_Correr_Parado(movement);
        }
    }

    IEnumerator Interact()
    {
        Vector2 vDirection = new Vector2(input_x, input_y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vDirection, 0.7f, LayerMask.NameToLayer(Layers.INTERACTABLE));
        Debug.DrawRay(transform.position, vDirection, Color.red, 1);

        /*
        if (hit)
            Debug.Log(hit.collider.tag);
        */
        if (hit && Input.GetKeyDown(KeyCode.Space) && state != PlayerState.Interacting)
        {
            StopMovement();
            state = PlayerState.Interacting;
            var interactable = hit.collider.GetComponent<Interactable>();
            yield return StartCoroutine(interactable.Interact());
            state = PlayerState.Running;
        }
    }

    void StopMovement()
    {
        movement = new Vector2(0, 0);
        PlayerAnimHandler.Estado_Correr_Parado(movement);
    }
}
