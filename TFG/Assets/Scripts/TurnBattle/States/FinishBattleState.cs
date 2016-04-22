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
        if (FighterActionManager.Instance.EnemyFighters.Count > 0)
            tb.ChangeState(tb.ChooseFighter);
        else
        {
           
            tb.CleanAndFinish();
        }
    }
}
