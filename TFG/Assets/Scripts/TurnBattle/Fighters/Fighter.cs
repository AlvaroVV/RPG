using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Fighter : MonoBehaviour {

    //Atributos comunes de Fighter
    public string FighterName { get; set; }
    public Sprite FighterImage { get; set; }
    public Animator FighterAnimator { get; set; }
    public BaseCharacter FighterData { get; set; }

    public TurnFighterPanel TurnFighterPanel { get; set; }

    public GameObject attackEffect { get; set; }

    public void SetIdleState()
    {
        FighterAnimator.SetTrigger("Idle");
    }

    

    public void addTurnPanel(TurnFighterPanel turn)
    {
        TurnFighterPanel = turn;
        turn.addFighter(this);
    }

    public abstract void SetDamage(int damage);
    public abstract void ChooseAttack();
    public abstract void ChooseTarget();
    public abstract void ChooseState();
}
