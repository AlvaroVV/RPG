using UnityEngine;
using System.Collections;
using System;

public class CharacterFighter : Fighter {

    private HealthPanel statsPanel;
    private ActionPanel actionPanel;
    private GameObject target;
    private BaseStatCharacter characterData;

    public void setCharacterProperties(BaseStatCharacter characterData)
    {
        if (characterData != null)
        {
            anim = GetComponentInChildren<Animator>();
            this.characterData = characterData;
            fighterName = characterData.Name;
            fighterImage = characterData.face;
            anim.runtimeAnimatorController = characterData.animatorController;
        }
    }

    public BaseStatCharacter getCharacterData()
    {
        return characterData;
    }


    public void addHealthBar(HealthPanel statsPanel)
    {
        this.statsPanel = statsPanel;
        statsPanel.addCharacter(characterData);
    }

    public void addActionPanel(ActionPanel actionPanel)
    {
        this.actionPanel = actionPanel;
        actionPanel.addCharacter(this);
    }

    public override void GetDamage(int damage)
    {
        characterData.currentHP -= damage;
        statsPanel.updateCurrentHP();
    }

    public override void UseMagic(int MP)
    {
        characterData.currentMP -= MP;
        statsPanel.updateCurrentMP();
    }

    public override void ChooseAttack()
    {
        //Activamos el panel
        actionPanel.gameObject.SetActive(true);
    }

    public override IEnumerator ChooseTarget(TurnBattleHandler tb)
    {
        //Pasamos al cursor la lista 
        fightCursor.gameObject.SetActive(true);
        yield return fighterAction.waitForTarget(MouseControl);
    }
  
    public override void ResolveFighterAction()
    {
        //Eliminamos cursor 
        fightCursor.gameObject.SetActive(false);
        //Animacion del fighter
        getAnim().SetTrigger(ChooseTrigger(fighterAction.getAttackType()));
        //Animación del ataque
        Instantiate(fighterAction.getAttackAnimation(), fighterAction.getTarget().transform.position, Quaternion.identity);
        //Calcular daño
            //GameGlobal.calculateDamage(fighterAction.getDamage());
            //Mostrar el Daño   
        //Animación del objetivo
            fighterAction.getTarget().getAnim().SetTrigger("hurt");
    }

    private string ChooseTrigger(GameGlobals.AttackType attackType)
    {
        switch (attackType)
        {
            case GameGlobals.AttackType.Attack:
                return "Attack";

            case GameGlobals.AttackType.Magic:
                return "Magic";

            default:
                return "Idle";
        }
    }

    private void MouseControl()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1500, 1 << GameGlobals.LayerEnemy);
            if (hit)
            {
                fightCursor.ChangeTargetByClick(hit.collider.gameObject);
                target = hit.collider.gameObject;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && target != null)
        {

            fighterAction.setObjetive(target.GetComponent<Fighter>());
        }
    }

}
