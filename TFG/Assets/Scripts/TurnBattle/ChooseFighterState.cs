﻿using UnityEngine;
using System.Collections;
using System;

public class ChooseFighterState : IState
{

    private TurnBattleHandler tb;

    public ChooseFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    
    public void StartState()
    {
        Debug.Log("Felix elegido");
    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.T))
            changeState();
    }

    public void changeState()
    {
        tb.ChangeState(tb.finishBattle);
    }
}
