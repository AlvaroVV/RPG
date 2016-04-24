using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Fighter : MonoBehaviour {

    //Atributos comunes de Fighter
    public string FighterName { get; set; }
    public Sprite FighterImage { get; set; }
    public Animator FighterAnimator { get; set; }
    public BaseCharacter FighterData { get; set; }

    //Atributos para referencias en el TurnBattle
    public TurnBattleHandler TB { get; set; } //Referencia al objeto que tiene listas de enemigos y characters
    public TurnFighterPanel TurnFighterPanel { get; set; }

    public GameObject attackEffect { get; set; }

    public void SetIdleState()
    {
        FighterAnimator.SetTrigger("Idle");
    }

    public void SetDamage(int damage)
    {
        FighterData.currentHP -= damage;
    }

    public void addTurnPanel(TurnFighterPanel turn)
    {
        TurnFighterPanel = turn;
        turn.addFighter(this);
    }

    public abstract void ChooseAttack();
    public abstract void ChooseTarget();
    public abstract void ChooseState();
}
