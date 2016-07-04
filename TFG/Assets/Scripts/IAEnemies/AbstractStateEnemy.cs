using UnityEngine;
using System.Collections;

public abstract class AbstractStateEnemy {

    public StateMachineEnemy sm;

    public AbstractStateEnemy(StateMachineEnemy sm)
    {
        this.sm = sm;
    }

    public abstract void UpdateState();

    public abstract void OnTriggerEnter2D(Collider2D other);

    public abstract void ToPatrolState();

    public abstract void ToAlertState();

    public abstract void ToChaseState();
}
