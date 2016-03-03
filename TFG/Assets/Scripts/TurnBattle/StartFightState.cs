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
        for(int i = 0; i<tb.enemyFighters.Count ; i++)
        {
            tb.InstantiateEnemy(tb.enemyFighters[i], tb.EnemyPoints[i]);
        }
        changeState();
    }

    public void changeState()
    {
        tb.ChangeState(tb.chooseFighter); 
    }

   
}
