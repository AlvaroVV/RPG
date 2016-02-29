using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IStateEnemy
{
    private StateMachineEnemy sm;
    private int nextWayPoint;

    public PatrolState(StateMachineEnemy sm)
    {
        this.sm = sm;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GameGlobals.TagPlayer))
        {

        }
        else
            nextWayPoint = NextPosition();
    }

    public void ToAlertState()
    {
        sm.currentState = sm.alert;
    }

    public void ToChaseState()
    {
        sm.currentState = sm.chase;
    }

    public void ToPatrolState()
    {
        Debug.Log("Ya está patrullando");
    }

    public void UpdateState()
    {
        if(!sm.DoPatrol)
            Patrol();
        Look();
    }

    void Look()
    {     
        if (Vector2.Distance(sm.target.transform.position, sm.transform.position) < sm.RadiusChase)
            ToChaseState();
    }

    void Patrol()
    {       
        Vector3 position = Vector3.Lerp(sm.rgb.position,sm.wayPoints[nextWayPoint].position,Time.deltaTime * sm.speed);
        sm.rgb.position = position;
        if(Vector2.Distance(sm.rgb.position, sm.wayPoints[nextWayPoint].position) < sm.distancePoints )
        {
            nextWayPoint = NextPosition();
            sm.UpdateAnimation(sm.wayPoints[nextWayPoint].position);
        }
    }

    int NextPosition()
    {
        return UnityEngine.Random.Range(0,sm.wayPoints.Length-1);
    }

   
}
