using UnityEngine;
using System.Collections;
using System;

public class VerifyFighterState: IState {

    TurnBattleHandler tb;

    public VerifyFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void changeState()
    {
        if (FighterActionManager.Instance.EnemyFighters.Count > 0)
            tb.ChangeState(tb.ChooseFighter);
        else
            tb.ChangeState(tb.FinishBattle);
    }

    public IEnumerator UpdateState()
    {
        yield return FighterActionManager.Instance.VerifyState();
    }
}
