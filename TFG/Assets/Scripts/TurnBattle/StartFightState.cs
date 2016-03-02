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
        
    }

    public void changeState()
    {
        tb.ChangeState(tb.chooseFighter); 
    }

   
}
