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

    //Cursor de selección de Target
    public Cursor cursor { get; set; }

    //Enemy
    public StateMachineEnemy Enemy { get; set; }

    //List team
    public List<CharacterData> PlayerTeam { get; set; }
    public List<CharacterFighter> PlayerTeamFighters { get; set; }

    //Lists Enemies
    public List<EnemyData> EnemyDatas { get; set; }
    public List<EnemyFighter> EnemyFighters { get; set; }

    //TurnStack
    public List<Fighter> StackTurnFighter { get; set; }
    public Fighter CurrentFighter { get; set; }

    //States
    public StartFightTeamState StartTeam { get; set; }
    public StartFightEnemiesState StartEnemies { get; set; }
    public ChooseFighterState ChooseFighter { get; set; }
    public FinishBattleState FinishBattle { get; set; }
    public ChooseActionState ChooseAction { get; set; }
    public ChooseEnemyState ChooseEnemy { get; set; }
    public ExecuteActionState ExecuteAction { get; set; }

    private IState currentState;

    void Awake()
    {
        //Inicializamos los estados
        StartTeam = new StartFightTeamState(this);
        StartEnemies = new StartFightEnemiesState(this);
        ChooseFighter = new ChooseFighterState(this);
        ChooseAction = new ChooseActionState(this);
        ChooseEnemy = new ChooseEnemyState(this);
        ExecuteAction = new ExecuteActionState(this);
        FinishBattle = new FinishBattleState(this);
        StackTurnFighter = new List<Fighter>();
        PlayerTeamFighters = new List<CharacterFighter>();
        EnemyFighters = new List<EnemyFighter>();
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;
    }

    public IEnumerator StartFight(StateMachineEnemy enemy)
    {
        //Cogemos listas de Enemigos y Team
        this.Enemy = enemy;
        PlayerTeam = GameGlobals.player.playerTeam;

        currentState = StartTeam;

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


    public void CleanAndFinish()
    {
        CleanEnemiesList(); //TEMPORAL
        CleanStackList(); //TEMPORAL
        StartCoroutine(GameGlobals.FinishFight());
        GameGlobals.player.StateIdle();
        currentState = null;
       
    }

    private void CleanEnemiesList()
    {
        foreach (EnemyFighter enemy in EnemyFighters)
            DestroyObject(enemy.gameObject);
        EnemyFighters = new List<EnemyFighter>();
    }

    private void CleanStackList()
    {
        Destroy(cursor.gameObject);
        StackTurnFighter = new List<Fighter>();
    }

    public void CleanCharactersList()
    {
        foreach (CharacterFighter charac in PlayerTeamFighters)
            DestroyObject(charac.gameObject);
        PlayerTeamFighters = new List<CharacterFighter>();
    }

    public void DestroyObject(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
        Destroy(gameObject.gameObject);
    }

}
