using UnityEngine;
using System.Collections;

public abstract class Fighter : MonoBehaviour {

    public string fighterName = "Fighter";
    public Sprite fighterImage;
    public Animator anim;
    public FighterAction fighterAction;
    private TurnFighterPanel turnFighterPanel;

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

    public abstract void setActivePanelAction(bool activate);
}
