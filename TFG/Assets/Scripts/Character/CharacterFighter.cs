using UnityEngine;
using System.Collections;
using System;

public class CharacterFighter : Fighter {

    private BaseStatCharacter characterData;
    private HealthPanel statsPanel;
    private ActionPanel actionPanel;
    private GameObject target;

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

    public BaseStatCharacter getEnemyData()
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

    public void Damage(int damage)
    {
        characterData.currentHP -= damage;
        statsPanel.updateCurrentHP();
    }

    public void UseMagic(int MPs)
    {
        characterData.currentMP -= MPs;
        statsPanel.updateCurrentMP();
    }

    public BaseStatCharacter getBaseStatCharacter()
    {
        return characterData;
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
        //Eliminamos cursor y ejecutamos FighterAction
        fightCursor.gameObject.SetActive(false);
        fighterAction.ExecuteFighterAction();
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
