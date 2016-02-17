using UnityEngine;
using System.Collections;
using System;

public class StartFightState : IState
{

    private TurnBattleHandler tb;

    public StartFightState (TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    
    public void StartState()
    {
        foreach (BaseCharacter bc in tb.players)
        {
            //Para cada personaje del grupo estado COMIENZO_BATALLA/APARECER
        }

        foreach (BaseCharacter bc in tb.enemies)
        {
            //Para cada enemigo poner estado COMIENZO_BATALLA/APARECER/LUCHANDO
        }
    }

    public void UpdateState()
    {
       //Corrutina, diálogo de batalla
    }

    public void changeState()
    {
        //Cambiar estado a ELEGIR_LUCHADOR
    }
}
