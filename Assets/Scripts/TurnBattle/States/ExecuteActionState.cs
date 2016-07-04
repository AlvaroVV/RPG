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
        tb.ChangeState(tb.ResolveAction);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("RESOLVE_ACTION");        
        yield return FighterActionManager.Instance.WaitForFinishAttackEffect();
    }
}
