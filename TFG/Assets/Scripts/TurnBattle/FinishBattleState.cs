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


    public IEnumerator UpdateState()
    {
        Debug.Log("FINISH BATTLE");
        yield return tb.WaitForKeyPressed(KeyCode.Space);
    }

    public void changeState()
    {
        tb.FinishBattle();
    }
}
