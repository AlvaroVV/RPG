using UnityEngine;
using System.Collections;

public abstract class Fighter : MonoBehaviour {

    public string fighterName = "Fighter";
    public Sprite fighterImage;
    public Animator anim;
    public FighterAction fighterAction;
    private TurnFighterPanel turnFighterPanel;
    public Cursor fightCursor;

    public Fighter()
    {
        fighterAction = new FighterAction();
    }

    public void addTurnPanel(TurnFighterPanel turn)
    {
        this.turnFighterPanel = turn;
        turn.addFighter(this);
    }

    public Animator getAnim()
    {
        return anim;
    }

    public FighterAction getFighterAction()
    {
        return fighterAction;
    }

    public void SetCursor(Cursor cursor)
    {
        fightCursor = cursor;
    }

    public abstract void UseMagic(int MP);
    public abstract void GetDamage(int damage);
    public abstract void ChooseAttack();
    public abstract IEnumerator ChooseTarget(TurnBattleHandler tb);
    public abstract void ResolveFighterAction();
}
