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

    public void UpdateState()
    {
        Debug.Log("CHOOSE_ACTION");
        Wait();
    }

    void Wait()
    {
        if (Input.GetKeyDown(KeyCode.T))
            changeState();
    }
}
