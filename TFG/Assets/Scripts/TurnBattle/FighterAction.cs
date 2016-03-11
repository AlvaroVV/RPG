using UnityEngine;
using System.Collections;
using System;

public class FighterAction  {

    private Action attack;
    private GameObject objetive;

    public FighterAction(Action action)
    {
        this.attack = action;
    }

    public void setObjetive(GameObject objetive)
    {
        this.objetive = objetive;
    }

    public void ExecuteAction()
    {
        attack();
    }
    
}
