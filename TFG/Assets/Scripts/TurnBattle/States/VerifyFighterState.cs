using UnityEngine;
using System.Collections;
using System.Linq;


public class VerifyFighterState: IState {

    TurnBattleHandler tb;

    public VerifyFighterState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public void changeState()
    {
        if (CheckHealthTeam() || FighterActionManager.Instance.EnemyFighters.Count == 0)
            tb.ChangeState(tb.FinishBattle);
        else 
            tb.ChangeState(tb.ChooseFighter);
    }

    public IEnumerator UpdateState()
    {
        yield return FighterActionManager.Instance.VerifyState();
    }

    private bool CheckHealthTeam()
    {
        bool finish = FighterActionManager.Instance.PlayerTeamFighters.Any(x => x.FighterData.HealthPoints <= 0);
        Debug.Log(finish);
        return finish;
    }
}
