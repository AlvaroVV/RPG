using UnityEngine;
using System.Collections;
using System;

public class AlertState : IStateEnemy
{
    private StateMachineEnemy sm;

    public AlertState(StateMachineEnemy sm)
    {
        this.sm = sm;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new NotImplementedException();
    }

    public void ToAlertState()
    {
        throw new NotImplementedException();
    }

    public void ToChaseState()
    {
        throw new NotImplementedException();
    }

    public void ToPatrolState()
    {
        throw new NotImplementedException();
    }

    public void UpdateState()
    {
        throw new NotImplementedException();
    }
}
