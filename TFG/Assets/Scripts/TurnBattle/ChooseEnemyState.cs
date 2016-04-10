using UnityEngine;
using System.Collections;
using System;

public class ChooseEnemyState : IState {

    private TurnBattleHandler tb;
    private Cursor cursor;
    private int targetNum = 0;
    private Fighter target;

    public ChooseEnemyState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void changeState()
    {
        tb.ChangeState(tb.resolveAction);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE_ENEMY");
        tb.currentFighter.SetCursor(tb.cursor);
        yield return tb.currentFighter.ChooseTarget(tb);
    }

}
