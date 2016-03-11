using UnityEngine;
using System.Collections;
using System;

public class ChooseActionState : IState
{

    private TurnBattleHandler tb;


    public ChooseActionState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void changeState()
    {
        tb.ChangeState(tb.chooseEnemy);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE_ACTION");
        tb.currentFighter.setActivePanelAction(true);
        yield return tb.currentFighter.getFighterAction().waitForAttack();
    }
}
