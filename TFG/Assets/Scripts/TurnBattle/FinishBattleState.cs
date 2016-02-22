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

    public void StartState()
    {
        
    }

    public void UpdateState()
    {
        Debug.Log("Finish Battle");
    }

    public void changeState()
    {

    }
}
