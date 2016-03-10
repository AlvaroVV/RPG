using UnityEngine;
using System.Collections;
using System;

public class ChooseFighterState : IState
{

    private TurnBattleHandler tb;

    public ChooseFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    
    public void UpdateState()
    {
        Debug.Log("CHOOSE FIGHTER");
        CombatGUI.Instance.CreateTurnFighterPanels(tb.stackTurnfighter);
        ActivateActionPanel();
        changeState();
    }

    private void ActivateActionPanel()
    {
        tb.stackTurnfighter[0].setActivePanelAction(true);
                       
    }
    public void changeState()
    {
        tb.ChangeState(tb.chooseAction);
    }
}
