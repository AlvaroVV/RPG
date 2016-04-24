using UnityEngine;
using System.Collections;
using System;

public class ResolveActionState : IState
{
    private TurnBattleHandler tb;

    public ResolveActionState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    public void changeState()
    {
        tb.ChangeState(tb.VerifyFighter);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("RESOLVE_ACTION");
        yield return FighterActionManager.Instance.ResolveAction();
    }
}
