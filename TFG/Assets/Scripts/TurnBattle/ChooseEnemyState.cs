﻿using UnityEngine;
using System.Collections;
using System;

public class ChooseEnemyState : IState {

    private TurnBattleHandler tb;

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
        yield return tb.WaitForKeyPressed(KeyCode.Space);
    }

}
