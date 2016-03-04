using UnityEngine;
using System.Collections;
using System;

public class ChooseFighterState : IState
{

    private TurnBattleHandler tb;

    public ChooseFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    
    public void UpdateState()
    {
        Debug.Log("CHOOSE FIGHTER");
       
        changeState();
    }

    IEnumerator WaitForKeyPress(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }
        yield return null;

    }

    public void changeState()
    {
        tb.ChangeState(tb.finishBattle);
    }
}
