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
        MapManager.Instance.GetActualMap().GetAudioSource().PlayGameOver();
        yield return new WaitForSeconds(2);
        CombatGUI.Instance.gameObject.SetActive(false);
        yield return ScriptingUtils.DoAFadeIn();
        
        GameObject gameOver = GameGlobals.GetCameraControll().GoToGameOver();
        yield return ScriptingUtils.DoAFadeOut();
        yield return ScriptingUtils.WaitForKeyPressed(KeyCode.Space);
        yield return ScriptingUtils.DoAFadeIn();

        UnityEngine.Object.Destroy(gameOver);
        yield return ScriptingUtils.DoAFadeOut();

        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

}
