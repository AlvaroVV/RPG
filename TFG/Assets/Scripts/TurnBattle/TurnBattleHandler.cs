using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler : MonoBehaviour{

    private IState currentState;
    private PlayerController pController;

    [HideInInspector]public List<BaseStatCharacter> players;
    [HideInInspector]public List<BaseStatCharacter> enemies;
    [HideInInspector]
    //Pila ordenada con los luchadores
    public List<BaseStatCharacter> fighterStack;

    [HideInInspector]
    public StartFightState startFight;
    [HideInInspector]
    public ChooseFighterState chooseFighter;
    [HideInInspector]
    public FinishBattleState finishBattle;

    void Awake()
    {
        pController = FindObjectOfType<PlayerController>();
        startFight = new StartFightState(this);
        chooseFighter = new ChooseFighterState(this);
        finishBattle = new FinishBattleState(this);
    }

    void Start()
    {
        players = pController.getTeam();
    }

  
    void Update()
    {
        if (currentState != null && currentState != finishBattle)
        {
            currentState.UpdateState();
            Debug.Log(currentState);
        }else if(currentState == finishBattle)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COMIENZA BATALLA");
        currentState = startFight;
        currentState.StartState();
    }

  

}
