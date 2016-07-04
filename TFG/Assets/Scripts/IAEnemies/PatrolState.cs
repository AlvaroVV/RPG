using UnityEngine;
using System.Collections;
using System;

public class PatrolState : AbstractStateEnemy
{
    private int nextWayPoint;
    private Vector3 initialPos;
    private float actualTime;

    public PatrolState(StateMachineEnemy sm): base(sm)
    {
        initialPos = sm.transform.position;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
          nextWayPoint = NextPosition();
    }

    public override void ToAlertState()
    {
        sm.currentState = sm.alert;
    }

    public override void ToChaseState()
    {
        sm.chase.targetDetected = true;
        sm.currentState = sm.chase;   
    }

    public override void ToPatrolState()
    {
        Debug.Log("Ya está patrullando");
    }

    public override void UpdateState()
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
        sm.UpdateAnimation(initialPos);
    }
   
}
