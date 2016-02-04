using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Se va a tratar de una máquina de estados
*/
public class TurnBattleHandler{

    private const int START_BATTLE = 0;
    private const int CHOOSE_FIGHTER = 1;
    private const int FIGHTER_ACTION = 2;
    private const int FIGHTER_ACTION_EFFECT = 3;
    private const int CHOOSE_NEXT_ACTION = 4;
    private const int FINISH_BATTLE = 5;

    private List<BaseCharacter> players;
    private List<BaseCharacter> enemigos;

    public TurnBattleHandler()
    {
        players = new List<BaseCharacter>();
        enemigos = new List<BaseCharacter>();
    }

}
