using UnityEngine;
using System.Collections;

public class EnemyFighter : MonoBehaviour {

    private Animator anim;
    private EnemyData enemyData;

    public void setEnemyProperties(EnemyData enemyData)
    {
        if(enemyData != null)
        {
            anim = GetComponentInChildren<Animator>();
            this.enemyData = enemyData;
            anim.runtimeAnimatorController = enemyData.animatorController;
        }            
    }

    public EnemyData getEnemyData()
    {
        return enemyData;
    }
}
