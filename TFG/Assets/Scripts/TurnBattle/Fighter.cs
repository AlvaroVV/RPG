using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Fighter : MonoBehaviour {

    //Atributos comunes de Fighter
    public string FighterName { get; set; }
    public Sprite FighterImage { get; set; }
    public Animator FighterAnimator { get; set; }
    public FighterAction fighterAction { get; set; }

    //Atributos para referencias en el TurnBattle
    public TurnBattleHandler TB { get; set; } //Referencia al objeto que tiene listas de enemigos y characters
    public TurnFighterPanel TurnFighterPanel { get; set; }

    public GameObject attackEffect { get; set; }

    public Fighter()
    {
        fighterAction = new FighterAction();
    }

    public void addTurnPanel(TurnFighterPanel turn)
    {
        TurnFighterPanel = turn;
        turn.addFighter(this);
    }


    public Cursor getFightCursor()
    {
        return TB.cursor;
    }

    public List<EnemyFighter> getEnemyFighterList()
    {
        return TB.EnemyFighters;
    }

    public List<CharacterFighter> getCharacterFighterList()
    {
        return TB.PlayerTeamFighters;
    }

    public void CreateAttackEffect()
    {
        if (fighterAction.getAttackAnimation() != null)
        {
            attackEffect = Instantiate(fighterAction.getAttackAnimation(), fighterAction.getTarget().transform.position, Quaternion.identity) as GameObject;
            fighterAction.getTarget().FighterAnimator.SetTrigger("hurt");
        }
        else
            Debug.LogError("No se ha cargado el ataque");
    }


    public IEnumerator WaitForFinishAttackEffect()
    {
        //Esperamos a que se cree el ataque
        while (attackEffect == null)
            yield return null;
        //Esperamos a que finalice
        while (attackEffect != null)
            yield return null;
    }


    public abstract void UseMagic(int MP);
    public abstract void GetDamage(int damage);
    public abstract void ChooseAttack();
    public abstract IEnumerator ChooseTarget(TurnBattleHandler tb);
    public abstract void ResolveFighterAction();
}
