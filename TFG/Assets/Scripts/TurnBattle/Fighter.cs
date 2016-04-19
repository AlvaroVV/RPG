using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Fighter : MonoBehaviour {

    //Atributos comunes de Fighter
    public string fighterName = "Fighter";
    public Sprite fighterImage;
    public Animator anim;
    public FighterAction fighterAction;

    //Atributos para referencias en el TurnBattle
    private TurnBattleHandler tb; //Referencia al objeto que tiene listas de enemigos y characters
    private TurnFighterPanel turnFighterPanel;

    public Fighter()
    {
        fighterAction = new FighterAction();
    }

    public void addTurnPanel(TurnFighterPanel turn)
    {
        this.turnFighterPanel = turn;
        turn.addFighter(this);
    }

    public Animator getAnim()
    {
        return anim;
    }

    public FighterAction getFighterAction()
    {
        return fighterAction;
    }

    public Cursor getFightCursor()
    {
        return tb.cursor;
    }

    public List<EnemyFighter> getEnemyFighterList()
    {
        return tb.enemyFighters;
    }

    public List<CharacterFighter> getCharacterFighterList()
    {
        return tb.playerTeamFighters;
    }

    public void SetTurnBattleHandler(TurnBattleHandler tb)
    {
        this.tb = tb;
    }

    public abstract void UseMagic(int MP);
    public abstract void GetDamage(int damage);
    public abstract void ChooseAttack();
    public abstract IEnumerator ChooseTarget(TurnBattleHandler tb);
    public abstract void ResolveFighterAction();
}
