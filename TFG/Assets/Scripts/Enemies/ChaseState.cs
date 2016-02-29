using UnityEngine;
using System.Collections;
using System;

public class ChaseState : IStateEnemy
{
    private StateMachineEnemy sm;
    private bool lost = false;

    public ChaseState(StateMachineEnemy sm)
    {
        this.sm = sm;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GameGlobals.TagPlayer))
        {

        }
        else
            ToPatrolState();
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
        sm.lost = true;
        sm.currentState = sm.patrol;
    }

    public void UpdateState()
    {
        sm.UpdateAnimation(sm.target.transform.position);
        if ((Vector2.Distance(sm.target.transform.position,sm.transform.position)<sm.RadiusChase) && (!lost))
        {
            sm.transform.position = Vector3.Lerp(sm.rgb.position, sm.target.transform.position, Time.deltaTime * sm.speed); ;
        }
        else
            ToPatrolState();
    }
}
