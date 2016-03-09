using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

    public string fighterName = "Fighter";
    public Sprite fighterImage;
    public Animator anim;

    private TurnFighterPanel turnFighterPanel;

	public void addTurnPanel(TurnFighterPanel turn)
    {
        this.turnFighterPanel = turn;
        turn.addFighter(this);
    }

    public Animator getAnim()
    {
        return anim;
    }
}
