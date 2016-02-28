using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    [Range(1, 5)]
    public float speed = 1.0f;

    private Rigidbody2D rgb;
    private float input_x;
    private float input_y;
    private Vector2 movement;

    private PlayerAnimHandler anim;

    public GameGlobals.PlayerState currentState;

    public virtual void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimHandler>();
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
        if (currentState != GameGlobals.PlayerState.Interacting)
        {
            rgb.MovePosition(rgb.position + movement * Time.fixedDeltaTime);
            anim.Estado_Correr_Parado(movement);
        }
        
    }

    IEnumerator Interact()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && currentState != GameGlobals.PlayerState.Interacting)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 0.7f, 1 << GameGlobals.LayerInteractable);
            //Debug.DrawRay(transform.position, movement, Color.red, 1);

            if (hit)
            {
                StopMovement();
                currentState = GameGlobals.PlayerState.Interacting;
                var interactable = hit.collider.GetComponent<Interactable>();
                yield return interactable.Interact();
                currentState = GameGlobals.PlayerState.Idle;
            }
        }
    }

    

    public void StopMovement()
    {
        movement = new Vector2(0, 0);
        anim.Estado_Correr_Parado(movement);
    }
}
