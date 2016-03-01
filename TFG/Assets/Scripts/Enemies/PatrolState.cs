using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IStateEnemy
{
    private StateMachineEnemy sm;
    private int nextWayPoint;
    private Vector3 initialPos;
    private float actualTime;

    public PatrolState(StateMachineEnemy sm)
    {
        this.sm = sm;
        initialPos = sm.transform.position;
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
        if (sm.wayPoints.Length>1)
            Patrol();
        else
            BackPosition();
        Look();
    }

    void Look()
    {
        if (Vector2.Distance(sm.target.transform.position, sm.transform.position) < sm.RadiusChase)
            ToChaseState();
    }

    void Patrol()
    {
         
        sm.rgb.position = Vector3.Lerp(sm.rgb.position, sm.wayPoints[nextWayPoint].position, Time.deltaTime * sm.speedPatrol);
        sm.UpdateAnimation(sm.wayPoints[nextWayPoint].position);
        if (Vector2.Distance(sm.rgb.position, sm.wayPoints[nextWayPoint].position) < sm.distancePoints)
        {
            actualTime += Time.deltaTime;
            if (actualTime >= sm.timeBetweenPoints)
            {
                nextWayPoint = NextPosition();
                actualTime = 0.0f;
            }
        }
    }

    int NextPosition()
    {
        return UnityEngine.Random.Range(0,sm.wayPoints.Length);
    }

    void BackPosition()
    {
        sm.rgb.position = Vector3.Lerp(sm.rgb.position, initialPos, Time.deltaTime * sm.speedPatrol);
        sm.UpdateAnimation(sm.rgb.position);
    }
   
}
