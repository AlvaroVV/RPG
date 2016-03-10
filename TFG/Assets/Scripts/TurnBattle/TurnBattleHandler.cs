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

    //List team
    [HideInInspector] public List<BaseStatCharacter> playerTeam;
    [HideInInspector]public List<GameObject> playerTeamFighters;

    //Lists Enemies
    [HideInInspector]public List<EnemyData> enemyDatas;
    [HideInInspector]public List<GameObject> enemyFighters;

    //TurnStack
    [HideInInspector]public List<Fighter> stackTurnfighter;

    //States
    [HideInInspector]public StartFightState startFight;
    [HideInInspector]public ChooseFighterState chooseFighter;
    [HideInInspector]public FinishBattleState finishBattle;
    [HideInInspector]public ChooseActionState chooseAction;

    private IState currentState;

    void Awake()
    {
        //Inicializamos los estados
        startFight = new StartFightState(this);
        chooseFighter = new ChooseFighterState(this);
        finishBattle = new FinishBattleState(this);
        chooseAction = new ChooseActionState(this);
        stackTurnfighter = new List<Fighter>();
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

    public void InstantiateTeam()
    {
       
        playerTeam = GameGlobals.player.playerTeam;

        for (int i = 0; i<playerTeam.Count; i++)
        {
            GameObject characObject = Resources.Load("Characters/CharacterFighter") as GameObject;
            GameObject characInstantiate = GameObject.Instantiate(characObject, CharacterPoints[i].transform.position, Quaternion.identity) as GameObject;

            CharacterFighter characterFighter = characInstantiate.GetComponent<CharacterFighter>();
            characterFighter.setCharacterProperties(playerTeam[i]);
            characInstantiate.name = playerTeam[i].name;
            characInstantiate.transform.parent = gameObject.transform;

            playerTeamFighters.Add(characInstantiate);
            stackTurnfighter.Add(characterFighter);
        }

        //Creamos el panel CombatGUI y asignamos barras de vida
        UIManager.Instance.CreateCombatGUI("UI/CombatGUI");
        CombatGUI.Instance.CreateCharactersPanels(playerTeamFighters);


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
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();
        currentState = null;
       
    }

    private void CleanEnemiesList()
    {
        foreach (GameObject enemy in enemyFighters)
            DestroyEnemy(enemy);
        enemyFighters = new List<GameObject>();
    }

    public void CleanCharactersList()
    {
        foreach (GameObject charac in playerTeamFighters)
            DestroyEnemy(charac);
        playerTeamFighters = new List<GameObject>();
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.SetParent(null);
        Destroy(enemy.gameObject);
    }

}
