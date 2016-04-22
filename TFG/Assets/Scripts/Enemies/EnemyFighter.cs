using UnityEngine;
using System.Collections;
using System;

public class EnemyFighter : Fighter {

    public EnemyData EnemyData { get; set; }

    public void setEnemyProperties(EnemyData enemyData)
    {
        if(enemyData != null)
        {
            FighterAnimator = GetComponentInChildren<Animator>();
            EnemyData = enemyData;
            FighterAnimator.runtimeAnimatorController = enemyData.animatorController;
            FighterName = enemyData.Name;
        }            
    }

    public override void ChooseAttack()
    {
        //IA para elegir el ataque
        Debug.Log("El enemigo no tiene Action Panel");
    }

    public override void ChooseTarget()
    {
        //IA para elegir target
   
    }

    public override void ChooseState()
    {
        throw new NotImplementedException();
    }


}
