using UnityEngine;
using System.Collections;

public class StateMachineEnemy : MonoBehaviour {

    public Transform[] wayPoints;
    [Range(0.1f, 3)]
    public float speed = 0.5f;
    public float distancePoints = 0.4f;
    public bool DoPatrol = false;
    [Range(0,2)]
    public float RadiusChase = 1f;

    private bool flipped = false;
    [HideInInspector]
    public bool lost = false;
    [HideInInspector]public GameObject target;
    [HideInInspector]public Rigidbody2D rgb;
    [HideInInspector]public Animator anim;
    [HideInInspector]public IStateEnemy currentState;
    //States
    [HideInInspector]public PatrolState patrol;
    [HideInInspector]public AlertState alert;
    [HideInInspector]public ChaseState chase;


    void Awake () {
        patrol = new PatrolState(this);
        alert = new AlertState(this);
        chase = new ChaseState(this);
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        target = GameObject.FindGameObjectWithTag(GameGlobals.TagPlayer);
	}

    void Start()
    {
        currentState = patrol;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentState.UpdateState();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(other);
    }

    public void Flip(Vector2 position)
    {
        if ((((position.x < 0) && (position.y < 0)) || ((position.x > 0) && (position.y > 0))) && !flipped)
        {
            flipped = true;
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }
        else if(!(((position.x < 0) && (position.y < 0)) || ((position.x > 0) && (position.y > 0)))&& flipped)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            flipped = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadiusChase);
        
    }

    public void UpdateAnimation(Vector2 movement)
    {
        Vector2 position = new Vector2(movement.x - rgb.position.x, movement.y - rgb.position.y) * 2;
        Debug.Log(position);
        Flip(position);
        anim.SetFloat(GameGlobals.INPUT_Y, position.y);
    }
}
