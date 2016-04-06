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
        Debug.Log(tb.stackTurnfighter.Count);
        createCursor();
        yield return ChooseTarget();
    }

    private void createCursor()
    {
        GameObject cursorRes = Resources.Load("UI/Cursor") as GameObject;
        GameObject cursorObj = GameObject.Instantiate(cursorRes, tb.stackTurnfighter[targetNum].transform.position, Quaternion.identity) as GameObject;
        cursorObj.transform.parent = tb.transform;
        cursor = cursorObj.GetComponent<Cursor>();
        cursor.ChangeTarget(tb.enemyFighters[targetNum]);
    }

    private void changeTarget()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            targetNum++;
            cursor.ChangeTarget(tb.enemyFighters[targetNum]);
            if (targetNum == tb.enemyFighters.Count-1) targetNum = -1;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            target = tb.stackTurnfighter[targetNum];
        }

    }

    private IEnumerator ChooseTarget()
    {
        while (target == null)
        {
            changeTarget();
            yield return null;
        }
        yield return null;
    }

}
