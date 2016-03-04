using UnityEngine;
using System.Collections;
using System;

public class FinishBattleState : IState
{
    private TurnBattleHandler tb;

    public FinishBattleState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }


    public void UpdateState()
    {
        Debug.Log("FINISH BATTLE");
        changeState();
    }

    public void changeState()
    {
        tb.FinishBattle();
    }
}
