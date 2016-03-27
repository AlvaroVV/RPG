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

    //Enemy
    [HideInInspector]public StateMachineEnemy enemy;

    //List team
    [HideInInspector] public List<BaseStatCharacter> playerTeam;
    [HideInInspector]public List<GameObject> playerTeamFighters;

    //Lists Enemies
    [HideInInspector]public List<EnemyData> enemyDatas;
    [HideInInspector]public List<GameObject> enemyFighters;

    //TurnStack
    [HideInInspector]public List<Fighter> stackTurnfighter;
    [HideInInspector]public Fighter currentFighter;

    //States
    [HideInInspector]public StartfightTeamState startTeam;
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
        startTeam = new StartfightTeamState(this);
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
        CleanEnemiesList(); //TEMPORAL
        CleanStackList(); //TEMPORAL
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();
        currentState = null;
       
    }

    private void CleanEnemiesList()
    {
        foreach (GameObject enemy in enemyFighters)
            Destroy(enemy);
        enemyFighters = new List<GameObject>();
    }

    private void CleanStackList()
    {
        foreach(Fighter fighter in stackTurnfighter)
            Destroy(fighter);
        stackTurnfighter = new List<Fighter>();
    }

    public void CleanCharactersList()
    {
        foreach (GameObject charac in playerTeamFighters)
            Destroy(charac);
        playerTeamFighters = new List<GameObject>();
    }

    public void Destroy(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.SetParent(null);
        UnityEngine.Object.Destroy(enemy.gameObject);
    }

}
