using UnityEngine;
using System.Collections;
using System;

public class ExecuteActionState : IState {

    private TurnBattleHandler tb;

    public ExecuteActionState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    public void changeState()
    {
        tb.ChangeState(tb.FinishBattle);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("RESOLVE_ACTION");
        tb.CurrentFighter.ResolveFighterAction();
        yield return tb.CurrentFighter.WaitForFinishAttackEffect();
    }
}
