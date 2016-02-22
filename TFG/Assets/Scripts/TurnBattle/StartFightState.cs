using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StartFightState : IState
{

    private TurnBattleHandler tb;

    public StartFightState (TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    
    public void StartState()
    {

       CreateEnemies();

        foreach (BaseCharacter bc in tb.players)
        {
            //Para cada personaje del grupo estado COMIENZO_BATALLA/APARECER
            Debug.Log(bc.name + " en posición de batalla");
        }

        foreach (BaseCharacter bc in tb.enemies)
        {
            //Para cada enemigo poner estado COMIENZO_BATALLA/APARECER/LUCHANDO
            Debug.Log("Un " + bc.name +" ha aparecido");
        }
    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.T))
            changeState();
    }



    

    public void changeState()
    {
        tb.ChangeState(tb.chooseFighter); 
    }

    void CreateEnemies()
    {
        tb.enemies = new List<BaseStatCharacter>();
        tb.enemies.Add(new BaseStatCharacter("Enemy_1"));
        tb.enemies.Add(new BaseStatCharacter("Enemy_2"));
        tb.enemies.Add(new BaseStatCharacter("Enemy_3"));
        tb.enemies.Add(new BaseStatCharacter("Enemy_4"));
    }

   
}
