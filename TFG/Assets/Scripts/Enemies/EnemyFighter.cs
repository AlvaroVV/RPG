using UnityEngine;
using System.Collections;

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
}
