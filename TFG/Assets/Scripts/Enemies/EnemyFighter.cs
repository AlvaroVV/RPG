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

    public override IEnumerator ChooseTarget(TurnBattleHandler tb)
    {
        //IA para elegir target
        yield return null;
    }

    public override void ResolveFighterAction()
    {
       
    }

    public override void GetDamage(int damage)
    {
        EnemyData.currentHP -= damage;
    }

    public override void UseMagic(int MP)
    {
        EnemyData.currentMP -= MP;
    }

   
}
