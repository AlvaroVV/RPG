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

    public override void setActivePanelAction(bool activate)
    {
        Debug.Log("El enemigo no tiene Action Panel");
    }
}
