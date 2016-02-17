using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler : MonoBehaviour{

    private IState currentState;

    [HideInInspector]public List<BaseCharacter> players;
    [HideInInspector]public List<BaseCharacter> enemies;
   
    void Start()
    {
        //currentState = StartFightState();
        currentState.StartState();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(IState nextState)
    {
        currentState = nextState;
    }
}
