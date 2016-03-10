using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class StartFightState : IState
{

    private TurnBattleHandler tb;

    public StartFightState (TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void UpdateState()
    {
        Debug.Log("START FIGHT");
        InstantiateEnemies();
        changeState();
    }
 

    public void changeState()
    {
        tb.ChangeState(tb.chooseFighter); 
    }

    private void InstantiateEnemies()
    {
        for(int i = 0; i< tb.enemyDatas.Count; i++)
        {
            InstantiateEnemy(tb.enemyDatas[i], tb.EnemyPoints[i]);        
        }
        
    }


    private void InstantiateEnemy(EnemyData enemyData,Transform transform)
    {
        GameObject enemyObject = Resources.Load("Enemies/EnemyFighter") as GameObject;
        GameObject enemyInstantiate = GameObject.Instantiate(enemyObject, transform.position, Quaternion.identity) as GameObject;

        EnemyFighter enemyFighter = enemyInstantiate.GetComponent<EnemyFighter>();

        enemyFighter.setEnemyProperties(enemyData);
        enemyInstantiate.transform.parent = tb.transform;

        enemyInstantiate.name = ChooseName(enemyData.Name);
        enemyFighter.fighterName = enemyInstantiate.name;

        tb.enemyFighters.Add(enemyInstantiate);
        tb.stackTurnfighter.Add(enemyFighter);
    }

    private string ChooseName(string name)
    {
        return name+"_" + (tb.enemyFighters.Where( fighter => fighter.GetComponent<EnemyFighter>().fighterName.StartsWith(name)).Count() +1);
    }
}
