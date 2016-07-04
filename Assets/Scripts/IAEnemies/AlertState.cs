using UnityEngine;
using System.Collections;
using System;

public class AlertState : AbstractStateEnemy
{

    private float currentTime;

    public AlertState(StateMachineEnemy sm):base(sm)
    {

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
         ToPatrolState(); // Si choca con algo que no sea el jugador
    }

    public override void ToAlertState()
    {

    }

    public override void ToChaseState()
    {
        sm.currentState = sm.chase;
    }

    public override void ToPatrolState()
    {
        sm.currentState = sm.patrol;
    }

    public override void UpdateState()
    {
        Alert();
        Look();
    }

    void Alert()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= sm.timeSearch)
        {
            currentTime = 0.0f;
            ToPatrolState();
            
        }
    }

    void Look()
    {
        if (Vector2.Distance(sm.target.transform.position, sm.transform.position) < sm.RadiusChase)
            ToChaseState();
    }
}
