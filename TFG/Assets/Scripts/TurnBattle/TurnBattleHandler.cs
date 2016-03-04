using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler : MonoBehaviour{

    //Puntos de aparación
    public Transform[] EnemyPoints;
    public Transform[] CharacterPoints;

    //Lists
    [HideInInspector]public List<EnemyData> enemyDatas;
    [HideInInspector]public List<GameObject> enemyFighters;

    //States
    [HideInInspector]public StartFightState startFight;
    [HideInInspector]public ChooseFighterState chooseFighter;
    [HideInInspector]public FinishBattleState finishBattle;

    private IState currentState;

    void Awake()
    {
        //Inicializamos los estados
        startFight = new StartFightState(this);
        chooseFighter = new ChooseFighterState(this);
        finishBattle = new FinishBattleState(this);
    }

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

    public void StartFight(StateMachineEnemy enemy)
    {
        //Guardamos la lista de enemigos
        enemyDatas = new List<EnemyData>(enemy.EnemyTeam);

        //Destruimos la IA del enemigo
        Destroy(enemy.gameObject);
      
        currentState = startFight;

    }

    /*
    public void CharacterPerformAction(CharacterAction action)
    {
        CombatGUI.ShowCharacterCombatInterface(character, OnCharacterPerformAction);
    }

    void OnCharacterPerformAction(CharacterAction action)
    {

    }
    */


    public void FinishBattle()
    {
        foreach (GameObject enemy in enemyFighters)
            DestroyEnemy(enemy);
        enemyFighters = new List<GameObject>();
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();
        currentState = null;
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.SetParent(null);
        Destroy(enemy.gameObject);
    }

}
