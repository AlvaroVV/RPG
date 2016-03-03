using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachineEnemy : MonoBehaviour {

    public Transform[] wayPoints;
    [Range(0.1f, 3)]
    public float speedPatrol = 0.5f;
    [Range(0.1f, 1)]
    public float distancePoints = 0.4f;
    [Range(0,2)]
    public float RadiusChase = 1f;
    [Range(0.2f,2)]
    public float speedChase = 0.5f;
    [Range(0, 5)]
    public float timeBetweenPoints = 1.0f;
    [Range(0, 5)]
    public float timeSearch = 2.0f;

    //Lista de enemigos que saldrán al tocarlo
    public List<EnemyData> EnemyTeam;

    [HideInInspector]public GameObject target;
    [HideInInspector]public Rigidbody2D rgb;
    [HideInInspector]public Animator anim;
    [HideInInspector]public IStateEnemy currentState;
    //States
    [HideInInspector]public PatrolState patrol;
    [HideInInspector]public AlertState alert;
    [HideInInspector]public ChaseState chase;


    private bool catched = false;

    //Referencias para cuando se empiece la batalla
    private GameObject background;
    private GameObject turnBattle;

    void Awake () {
        
        patrol = new PatrolState(this);
        alert = new AlertState(this);
        chase = new ChaseState(this);
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        target = GameGlobals.player.gameObject;
    }

    void Start()
    {
        currentState = patrol;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!catched)
            currentState.UpdateState();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(GameGlobals.TagPlayer))
        {
            Catched();
            StartFight();
        }
        else
        {
            currentState.OnTriggerEnter2D(other);
        }
       
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadiusChase);
        
    }

    public void UpdateAnimation(Vector2 newPosition)
    {
        Vector2 position = newPosition - rgb.position;
        anim.SetFloat(GameGlobals.INPUT_Y, position.y *10);
        anim.SetFloat(GameGlobals.INPUT_X, position.x *10);
        //Flip(position);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void StartFight()
    {

        StartCoroutine(GameGlobals.StartFight(this));
        //DestroyEnemy();
          
    }

    void Catched()
    {
        catched = true;
        rgb.velocity = Vector3.zero;
    }

    
}
