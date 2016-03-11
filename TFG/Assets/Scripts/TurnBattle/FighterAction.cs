using UnityEngine;
using System.Collections;
using System;

public class FighterAction  {

    private Action attack; //Acción elegida
    private GameObject objetive; //Enemigo elegido

    public void setAttack(Action attack)
    {
        this.attack = attack;
    }

    public void setObjetive(GameObject objetive)
    {
        this.objetive = objetive;
    }

    public void ExecuteAction()
    {
        attack();
    }

    public IEnumerator waitForAttack()
    {
        while (attack == null)
            yield return null;
    }
    
}
