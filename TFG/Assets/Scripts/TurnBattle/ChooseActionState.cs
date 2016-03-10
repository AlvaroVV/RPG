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
        tb.ChangeState(tb.finishBattle);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE_ACTION");
        tb.currentFighter.setActivePanelAction(true);
        yield return tb.WaitForKeyPressed(KeyCode.Space);
    }

    void Wait()
    {
        if (Input.GetKeyDown(KeyCode.T))
            changeState();
    }
}
