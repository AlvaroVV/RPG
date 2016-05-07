using UnityEngine;
using System.Collections;
using System;

public class EnemyFighter : Fighter {


    public void setEnemyProperties(EnemyData enemyData)
    {
        if(enemyData != null)
        {
            FighterAnimator = GetComponentInChildren<Animator>();
            FighterData = enemyData;
            FighterAnimator.runtimeAnimatorController = enemyData.animatorController;
            FighterName = enemyData.Name;
        }            
    }

    public override void ChooseAttack()
    {
        FighterActionManager.Instance.attackInfo = FighterData.normalAttack;
    }

    public override void ChooseTarget()
    {
        int random = UnityEngine.Random.Range(0, FighterActionManager.Instance.PlayerTeamFighters.Count);
        FighterActionManager.Instance.target = FighterActionManager.Instance.PlayerTeamFighters[random];
    }

    public override void ChooseState()
    {
        String state = FighterActionManager.Instance.attackInfo.FighterState.ToString();
        FighterAnimator.SetTrigger(state);
    }


}
