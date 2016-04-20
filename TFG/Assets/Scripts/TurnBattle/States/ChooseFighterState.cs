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
    
    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE FIGHTER");
        ChooseFighter();
        yield return null;
    }

    private void ChooseFighter()
    {
        tb.CurrentFighter = tb.StackTurnFighter[0];

    }
    public void changeState()
    {
        tb.ChangeState(tb.ChooseAction);
    }
}
