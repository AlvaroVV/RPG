using UnityEngine;
using System.Collections;
using System;

public class AlertState : IStateEnemy
{
    private StateMachineEnemy sm;
    private float currentTime;

    public AlertState(StateMachineEnemy sm)
    {
        this.sm = sm;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
         ToPatrolState(); // Si choca con algo que no sea el jugador
    }

    public void ToAlertState()
    {

    }

    public void ToChaseState()
    {
        sm.currentState = sm.chase;
    }

    public void ToPatrolState()
    {
        sm.currentState = sm.patrol;
    }

    public void UpdateState()
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
