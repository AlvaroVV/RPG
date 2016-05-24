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
    public StateMachineEnemy Enemy { get; set; }

    //List team
    public List<CharacterData> PlayerTeam { get; set; }

    //Lists Enemies
    public List<EnemyData> EnemyDatas { get; set; }

    //States
    public StartFightTeamState StartTeam { get; set; }
    public StartFightEnemiesState StartEnemies { get; set; }
    public ChooseFighterState ChooseFighter { get; set; }
    public ChooseActionState ChooseAction { get; set; }
    public ChooseEnemyState ChooseEnemy { get; set; }
    public ExecuteActionState ExecuteAction { get; set; }
    public ResolveActionState ResolveAction { get; set; }
    public VerifyFighterState VerifyFighter { get; set; }
    public FinishBattleState FinishBattle { get; set; }

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
        ResolveAction = new ResolveActionState(this);
        VerifyFighter = new VerifyFighterState(this);
        FinishBattle = new FinishBattleState(this);
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;
    }

    public IEnumerator StartFight(StateMachineEnemy enemy)
    {
        //Cogemos listas de Enemigos y Team
        this.Enemy = enemy;
        PlayerTeam = GameGlobals.playerTeam.playerTeam;
      
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
        FighterActionManager.Instance.CleanAndFinish();
        currentState = null;
    }

}
