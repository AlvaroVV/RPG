﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler : MonoBehaviour{

    //Puntos de aparación
    public Transform[] EnemyPoints;
    public Transform[] CharacterPoints;

    //Cursor de selección de Target
    [HideInInspector]public Cursor cursor;

    //Enemy
    [HideInInspector]public StateMachineEnemy enemy;

    //List team
    [HideInInspector]public List<CharacterData> playerTeam;
    [HideInInspector]public List<CharacterFighter> playerTeamFighters;

    //Lists Enemies
    [HideInInspector]public List<EnemyData> enemyDatas;
    [HideInInspector]public List<EnemyFighter> enemyFighters;

    //TurnStack
    [HideInInspector]public List<Fighter> stackTurnfighter;
    [HideInInspector]public Fighter currentFighter;

    //States
    [HideInInspector]public StartFightTeamState startTeam;
    [HideInInspector]public StartFightEnemiesState startEnemies;
    [HideInInspector]public ChooseFighterState chooseFighter;
    [HideInInspector]public FinishBattleState finishBattle;
    [HideInInspector]public ChooseActionState chooseAction;
    [HideInInspector]public ChooseEnemyState chooseEnemy;
    [HideInInspector]public ResolveActionState resolveAction;

    private IState currentState;

    void Awake()
    {
        //Inicializamos los estados
        startTeam = new StartFightTeamState(this);
        startEnemies = new StartFightEnemiesState(this);
        chooseFighter = new ChooseFighterState(this);
        chooseAction = new ChooseActionState(this);
        chooseEnemy = new ChooseEnemyState(this);
        resolveAction = new ResolveActionState(this);
        finishBattle = new FinishBattleState(this);
        stackTurnfighter = new List<Fighter>();
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;
    }

    public IEnumerator StartFight(StateMachineEnemy enemy)
    {
        //Cogemos listas de Enemigos y Team
        this.enemy = enemy;
        playerTeam = GameGlobals.player.playerTeam;

        currentState = startTeam;

        while(currentState != null)
        {
            yield return currentState.UpdateState();
            currentState.changeState();
        }
    }

    public IEnumerator WaitForKeyPressed(KeyCode key)
    {
        while(!Input.GetKeyDown(key))
        {
            yield return null;
        }

        yield return null;
    }


    public void FinishBattle()
    {
        CleanEnemiesList(); //TEMPORAL
        CleanStackList(); //TEMPORAL
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();
        currentState = null;
       
    }

    private void CleanEnemiesList()
    {
        foreach (EnemyFighter enemy in enemyFighters)
            DestroyObject(enemy.gameObject);
        enemyFighters = new List<EnemyFighter>();
    }

    private void CleanStackList()
    {
        Destroy(cursor.gameObject);
        stackTurnfighter = new List<Fighter>();
    }

    public void CleanCharactersList()
    {
        foreach (CharacterFighter charac in playerTeamFighters)
            DestroyObject(charac.gameObject);
        playerTeamFighters = new List<CharacterFighter>();
    }

    public void DestroyObject(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
        Destroy(gameObject.gameObject);
    }

}
