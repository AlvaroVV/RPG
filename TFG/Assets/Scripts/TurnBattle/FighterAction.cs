using UnityEngine;
using System.Collections;
using System;

public class FighterAction  {

    private Action attack; //Acción elegida
    private Fighter target; //Enemigo elegido

    public void setAttack(Action attack)
    {
        this.attack = attack;
    }

    public void setObjetive(Fighter objetive)
    {
        this.target = objetive;
    }

    public void ExecuteFighterAction()
    {
        attack();
    }

    public IEnumerator waitForAttack()
    {
        while (attack == null)
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
