using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [Range(1,5)]
    public float speed = 1.0f;

    private Rigidbody2D rgb;
    private float input_x;
    private float input_y;
    private bool isRunning;
    private Vector2 movement;

    private Animator anim;


	// Use this for initialization
	void Awake () {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerAnimHandler.Animator = anim;
	}

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal") ;
        input_y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(input_x, input_y) * speed;

        //Llamamos al handler de las animaciones del player que maneje Correr-Parado
        PlayerAnimHandler.Estado_Correr_Parado(movement);
           
    }


    void FixedUpdate ()
    {
        Movement();
        Interact();
	}


    void Movement()
    {
        rgb.MovePosition(rgb.position + movement * Time.fixedDeltaTime);
    }

    void Interact()
    {
        Vector2 vDirection = new Vector2(input_x, input_y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vDirection, 0.7f,LayerMask.NameToLayer(Layers.INTERACTABLE));
        Debug.DrawRay(transform.position, vDirection, Color.red,1);
        
        /*
        if (hit)
            Debug.Log(hit.collider.tag);
        */
        if (hit && Input.GetKeyDown(KeyCode.T))
        {
            var interactable = hit.collider.GetComponent<Interactable>();
            interactable.Interact();
        }
    }
}
