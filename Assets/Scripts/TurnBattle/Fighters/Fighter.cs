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

    private string State;

    public void SetIdleState()
    {
        FighterAnimator.SetTrigger("Idle");
        State = "Idle";
    }

    public void SetDeadState()
    {
        FighterAnimator.SetTrigger("Dead");
        State = "Dead";
    }

    public void SetHurtState()
    {
        FighterAnimator.SetTrigger("Hurt");
        State = "Hurt";
    }

    public string GetState()
    {
        return State;
    }

    public void SetState(string state)
    {
        State = state;
    }


    public void addTurnPanel(TurnFighterPanel turn)
    {
        TurnFighterPanel = turn;
        turn.addFighter(this);
    }

    public virtual void Health(int hp)
    {
        if(FighterData.currentHP + hp >= FighterData.HealthPoints)
            FighterData.currentHP = FighterData.HealthPoints;
        else
            FighterData.currentHP += hp;
    }

    public virtual void SetDamage(int damage)
    {
        if (FighterData.currentHP - damage < 0)
            FighterData.currentHP = 0;
        else
            FighterData.currentHP -= damage;
    }

    public virtual void UseMagic(int mp)
    {
        if (FighterData.currentMP - mp < 0)
            FighterData.currentMP = 0;
        else
            FighterData.currentMP -= mp;
    }

    public abstract void ChooseAttack();
    public abstract void ChooseTarget();
    public abstract void ChooseState();
}
