using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler : MonoBehaviour{

    private IState currentState;
    private PlayerTeam pController;

    [HideInInspector]public StartFightState startFight;
    [HideInInspector]public ChooseFighterState chooseFighter;
    [HideInInspector]public FinishBattleState finishBattle;

    void Update()
    {
        //Cuando llamamos desde fuera al StartFight le pasamos el Estado Start.
        if(currentState != null)
            currentState.UpdateState();
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;

    }

    public void StartFight(EnemyTeam enemy)
    {
        //Inicializamos los estados
        startFight = new StartFightState(this);
        chooseFighter = new ChooseFighterState(this);
        finishBattle = new FinishBattleState(this);

        //Conseguimos los equipos


        //Empezamos la pelea
        currentState = startFight;
    }

}
