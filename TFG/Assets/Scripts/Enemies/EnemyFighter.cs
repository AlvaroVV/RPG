using UnityEngine;
using System.Collections;

public class EnemyFighter : MonoBehaviour {

    public string fighterName = "Enemy";
    private Animator anim;
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
