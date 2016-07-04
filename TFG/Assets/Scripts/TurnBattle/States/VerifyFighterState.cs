using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class VerifyFighterState: IState {

    TurnBattleHandler tb;

    public VerifyFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void changeState()
    {
        if (CheckHealthTeam() && FighterActionManager.Instance.EnemyFighters.Count != 0)
            tb.ChangeState(tb.ChooseFighter);
        else if (!CheckHealthTeam())
            tb.ChangeState(tb.LooseAction);
        else
            tb.ChangeState(tb.FinishBattle);
    }

    public IEnumerator UpdateState()
    {
        yield return FighterActionManager.Instance.VerifyState();
    }

    private bool CheckHealthTeam()
    {
        bool finish = FighterActionManager.Instance.PlayerTeamFighters.Any(x => x.FighterData.currentHP > 0);
        return finish;
    }

}
