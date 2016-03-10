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
    
    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE FIGHTER");
        CombatGUI.Instance.CreateTurnFighterPanels(tb.stackTurnfighter);
        ActivateActionPanel();
        yield return tb.WaitForKeyPressed(KeyCode.Space);
    }

    private void ActivateActionPanel()
    {
        tb.currentFighter = tb.stackTurnfighter[0];

                       
    }
    public void changeState()
    {
        tb.ChangeState(tb.chooseAction);
    }
}
