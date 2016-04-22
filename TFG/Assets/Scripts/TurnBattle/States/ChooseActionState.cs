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
        tb.ChangeState(tb.ChooseEnemy);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("CHOOSE_ACTION");
        yield return FighterActionManager.Instance.WaitForAttack();
    }
}
