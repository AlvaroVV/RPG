using UnityEngine;
using System.Collections;
using System;

public class EnemyFighter : Fighter {

    private EnemyData enemyData;

    public void setEnemyProperties(EnemyData enemyData)
    {
        if(enemyData != null)
        {
            anim = GetComponentInChildren<Animator>();
            this.enemyData = enemyData;
            anim.runtimeAnimatorController = enemyData.animatorController;
            fighterName = enemyData.Name;
        }            
    }

    public EnemyData getEnemyData()
    {
        return enemyData;
    }

    public override void ChooseAttack()
    {
        //IA para elegir el ataque
        Debug.Log("El enemigo no tiene Action Panel");
    }

    public override IEnumerator ChooseTarget(TurnBattleHandler tb)
    {
        //IA para elegir target
        yield return null;
    }

    public override void ResolveFighterAction()
    {
       
    }
}
