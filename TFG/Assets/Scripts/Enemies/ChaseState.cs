﻿using UnityEngine;
using System.Collections;
using System;

public class ChaseState : IStateEnemy
{
    private StateMachineEnemy sm;
    private SpriteRenderer sR;
    private Color initialColor;
    public ChaseState(StateMachineEnemy sm)
    {
        this.sm = sm;
        sR = sm.GetComponentInChildren<SpriteRenderer>();
        initialColor = sR.color;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GameGlobals.TagPlayer))
        {
            sm.StartCoroutine(StartFight());
            
        }
        else
            ToPatrolState(); // Si choca con algo que no sea el jugador
    }

    public void ToAlertState()
    {
        sm.currentState = sm.alert;
    }

    public void ToChaseState()
    {
        
    }

    public void ToPatrolState()
    {
      
        sm.currentState = sm.patrol;
    }

    public void UpdateState()
    {
        sm.UpdateAnimation(sm.target.transform.position);
        if ((Vector2.Distance(sm.target.transform.position, sm.transform.position) < sm.RadiusChase)) 
        {
            Chase();
        }
        else
        {
            StopChasing();
            ToAlertState();
        }
    }

    void Chase()
    {
        sm.rgb.velocity = (sm.target.transform.position - sm.transform.position).normalized * sm.speedChase;
        sR.color = Color.red;
    }

    void StopChasing()
    {
        sm.rgb.velocity = Vector3.zero;
        sR.color = initialColor;
    }

   IEnumerator StartFight()
    {
        yield return GameGlobals.ChangeCameraToFight();
        sm.DestroyEnemy();
        GameObject back = GameObject.FindGameObjectWithTag(GameGlobals.TagBackground);
        GameGlobals.saveBackReference(back);
        back.SetActive(false);
        //yield return new WaitForSeconds(1);
        //GameGlobals.Backreference.SetActive(true);
    }
}
