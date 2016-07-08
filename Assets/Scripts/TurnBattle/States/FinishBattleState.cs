using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class FinishBattleState : IState
{
    private TurnBattleHandler tb;

    public FinishBattleState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }


    public IEnumerator UpdateState()
    {
        yield return ScriptingUtils.WaitForKeyPressed(KeyCode.Space);
        MapManager.Instance.GetActualMap().GetAudioSource().PlayAmbientSound();
    }

    public void changeState()
    {     
        tb.CleanAndFinish();

    }

}
