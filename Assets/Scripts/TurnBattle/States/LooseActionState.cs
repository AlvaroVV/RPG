using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LooseActionState : IState {

    TurnBattleHandler tb;

    public LooseActionState(TurnBattleHandler tb)
    {
        this.tb = tb;
    } 
    public void changeState()
    {
        tb.GameOver();
    }

    public IEnumerator UpdateState()
    {
        yield return tb.WaitForKeyPressed(KeyCode.Space);
        CombatGUI.Instance.gameObject.SetActive(false);
        yield return ScriptingUtils.DoAFadeIn();
        GameObject gameOver = GameGlobals.camera.GoToGameOver();
        yield return tb.WaitForKeyPressed(KeyCode.Space);
        yield return ScriptingUtils.DoAFadeIn();
        UnityEngine.Object.Destroy(gameOver);
        SceneManager.LoadScene(0);
    }

}
