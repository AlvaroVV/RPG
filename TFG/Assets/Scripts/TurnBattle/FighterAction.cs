using UnityEngine;
using System.Collections;
using System;

public class FighterAction  {

    public AttackInfo attackInfo; //Ataque elegido
    public Fighter target; //Enemigo elegido

    public void setAttack(AttackInfo attackInfo)
    {
        this.attackInfo = attackInfo;
    }

    public void setObjetive(Fighter objetive)
    {
        this.target = objetive;
    }

    public GameObject getAttackAnimation()
    {
        return attackInfo.Animation;
    }

    public int getDamage()
    {
        return attackInfo.Damage;
    }

    public GameGlobals.AttackType getAttackType()
    {
        return attackInfo.FighterState;
    }

    public Fighter getTarget()
    {
        return target;
        
    }

    public IEnumerator waitForAttack()
    {
        while (attackInfo == null)
            yield return null;
    }

    public IEnumerator waitForTarget(Action choose)
    {
        while (target == null)
        {
            choose();
            yield return null;
        }
    }
    
}
