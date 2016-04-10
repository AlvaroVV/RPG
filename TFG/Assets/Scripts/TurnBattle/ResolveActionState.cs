using UnityEngine;
using System.Collections;
using System;

public class ResolveActionState : IState {

    private TurnBattleHandler tb;

    public ResolveActionState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    public void changeState()
    {
        tb.ChangeState(tb.finishBattle);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("RESOLVE_ACTION");
        tb.currentFighter.ResolveFighterAction();
        yield return tb.WaitForKeyPressed(KeyCode.Space);
    }
}
