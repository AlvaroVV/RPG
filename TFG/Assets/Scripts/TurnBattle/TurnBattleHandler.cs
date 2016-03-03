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
    [HideInInspector]public List<EnemyData> enemyTeam;
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
        enemyTeam = new List<EnemyData>(enemy.EnemyTeam);

        //Destruimos la IA del enemigo
        Destroy(enemy.gameObject);

        foreach (EnemyData en in enemyTeam)
        {
            CreateFighter(en);
        }
      
        currentState = startFight;
    }

    private void CreateFighter(EnemyData enemy)
    {
        GameObject enemyObject = Resources.Load("Enemies/EnemyFighter") as GameObject;
        EnemyFighter enemyFighter = enemyObject.GetComponent<EnemyFighter>();

        enemyFighter.setEnemyProperties(enemy);
        enemyFighters.Add(enemyObject);

    }

    public void InstantiateEnemy(GameObject enemy, Transform transform)
    {
        Instantiate(enemy,transform.position,Quaternion.identity);
    }
}
