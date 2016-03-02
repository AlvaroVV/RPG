using UnityEngine;
using System.Collections;

public class StateMachineEnemy : MonoBehaviour {

    public Transform[] wayPoints;
    [Range(0.1f, 3)]
    public float speedPatrol = 0.5f;
    public float distancePoints = 0.4f;
    [Range(0,2)]
    public float RadiusChase = 1f;
    [Range(0.2f,2)]
    public float speedChase = 0.5f;
    public float timeBetweenPoints = 1.0f;
    public float timeSearch = 2.0f;

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
        if(other.gameObject.CompareTag(GameGlobals.TagPlayer))
        {
            StartCoroutine(StartFight());
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

    IEnumerator StartFight()
    {
        yield return GameGlobals.ChangeCameraToFight();
        DestroyEnemy();
        GameObject back = GameObject.FindGameObjectWithTag(GameGlobals.TagBackground);
        GameGlobals.saveBackReference(back);
        back.SetActive(false);
        
    }
}
