using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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

    IEnumerator WaitForKeyPress(KeyCode key)
    {
        while(!Input.GetKeyDown(key))
        {
            yield return null;
        }
        yield return null;

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
        EnemyFighter enemyFighter = enemyObject.GetComponent<EnemyFighter>();

        enemyFighter.setEnemyProperties(enemyData);

        GameObject enemyInstantiate = GameObject.Instantiate(enemyObject, transform.position, Quaternion.identity) as GameObject;
        enemyInstantiate.name = enemyData.name;
        enemyInstantiate.transform.parent = tb.transform;

        tb.enemyFighters.Add(enemyInstantiate);
    }
}
