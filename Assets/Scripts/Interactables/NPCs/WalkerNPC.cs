using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WalkerNPC : NPC {

    public List<GameObject> Waypoints;

    private Animator anim;
    private Rigidbody2D rgb;
    private NPC_State currentState;
    private enum NPC_State
    {
        Walking,
        Interacting,
    }
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        currentState = NPC_State.Walking; 
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(WalkingState());
	}


    public IEnumerator MoveToPosition(Vector2 point)
    {
        while (Vector2.Distance(transform.position, point) > 0.1)
        {
            Vector2 newDirection = new Vector2(point.x - rgb.position.x,
                                                point.y - rgb.position.y);

            rgb.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime);

            State_Walk_Stopped(newDirection);
            yield return null;
        }

        rgb.velocity = Vector2.zero;
        State_Walk_Stopped(Vector2.zero);

        yield return null;
    }


    private IEnumerator WalkingState()
    {
        currentState = NPC_State.Walking;

        while(currentState == NPC_State.Walking && Waypoints.Count>0)
        {
            int random = UnityEngine.Random.Range(0, Waypoints.Count - 1);


            Vector2 newPosition = Waypoints[random].transform.position;

            yield return MoveToPosition(newPosition);
            yield return new WaitForSeconds(2);
        }

        yield return null;
    }

    public IEnumerator WalkingPoints(List<GameObject> points)
    {
        foreach (GameObject point in points)
            yield return MoveToPosition(point.transform.position);
        yield return null;
    }


    private void StopMovement()
    {
        currentState = NPC_State.Interacting;
    }

 
    public override IEnumerator InteractNPC()
    {
        StopMovement();

        Vector2 direction = GameGlobals.player.transform.position - transform.position;
        State_Idle_Direction(direction);

        yield return ScriptingUtils.showNpcDialogue(this, true);

        StartCoroutine(WalkingState());

        yield return null;
    }

    private void State_Walk_Stopped(Vector2 direction)
    {

        if (direction != Vector2.zero)
        {
            anim.SetFloat("xValue", direction.x);
            anim.SetFloat("yValue", direction.y);
            anim.SetBool("isRunning", true);
        }
        else
            anim.SetBool("isRunning", false);

    }

    private void State_Idle_Direction(Vector2 direction)
    {
        anim.SetFloat("xValue", direction.x);
        anim.SetFloat("yValue", direction.y);
        anim.SetBool("isRunning", false);
    }
}
