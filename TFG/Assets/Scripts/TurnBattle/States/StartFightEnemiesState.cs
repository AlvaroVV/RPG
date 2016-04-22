using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class StartFightEnemiesState : IState
{

    private TurnBattleHandler tb;

    public StartFightEnemiesState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("START ENEMIES");
        InstantiateEnemies();
        CombatGUI.Instance.CreateTurnFighterPanels(FighterActionManager.Instance.StackTurnFighter);
        yield return tb.WaitForKeyPressed(KeyCode.Space);
        
    }
 

    public void changeState()
    {
        tb.ChangeState(tb.ChooseFighter); 
    }

    private void InstantiateEnemies()
    {
        //Guardamos la lista de enemigos
        tb.EnemyDatas = new List<EnemyData>(tb.Enemy.EnemyTeam);
        //Destruimos la IA del enemigo
        tb.DestroyObject(tb.Enemy.gameObject);

        for (int i = 0; i< tb.EnemyDatas.Count; i++)
        {
            InstantiateEnemy(tb.EnemyDatas[i], tb.EnemyPoints[i]);        
        }
        
    }


    private void InstantiateEnemy(EnemyData enemyData,Transform transform)
    {
        GameObject enemyObject = Resources.Load("Enemies/EnemyFighter") as GameObject;
        GameObject enemyInstantiate = GameObject.Instantiate(enemyObject, transform.position, Quaternion.identity) as GameObject;

        EnemyFighter enemyFighter = enemyInstantiate.GetComponent<EnemyFighter>();

        enemyFighter.setEnemyProperties(enemyData);
        enemyInstantiate.transform.parent = tb.transform;

        enemyInstantiate.name = ChooseName(enemyData.CharacterName);
        enemyFighter.FighterName = enemyInstantiate.name;

        FighterActionManager.Instance.EnemyFighters.Add(enemyFighter);
        FighterActionManager.Instance.StackTurnFighter.Add(enemyFighter);
    }

    private string ChooseName(string name)
    {
        return name+"_" + (FighterActionManager.Instance.EnemyFighters.Where( fighter => fighter.GetComponent<EnemyFighter>().FighterName.StartsWith(name)).Count() +1);
    }
}
