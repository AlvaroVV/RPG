using UnityEngine;
using System.Collections;
using System;
using System.Linq;

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
        //int random = UnityEngine.Random.Range(0, FighterActionManager.Instance.PlayerTeamFighters.Count);
        CharacterFighter random = (from f in FighterActionManager.Instance.PlayerTeamFighters
                                   where f.FighterData.currentHP > 0
                                   select f).OrderBy(x => Guid.NewGuid()).Take(50).FirstOrDefault();

        FighterActionManager.Instance.target = random;
    }

    public override void ChooseState()
    {
        string state = FighterActionManager.Instance.attackInfo.FighterState.ToString();
        FighterAnimator.SetTrigger(state);
    }


}
