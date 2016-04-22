using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class CharacterFighter : Fighter {

    private HealthPanel statsPanel;
    private ActionPanel actionPanel;
    private GameObject target;
    public CharacterData CharacterData { get; set; }

    public void setCharacterProperties(CharacterData characterData,TurnBattleHandler tb)
    {
        if (characterData != null)
        {
            FighterAnimator = GetComponentInChildren<Animator>();
            CharacterData = characterData;
            FighterName = characterData.Name;
            FighterImage = characterData.face;
            FighterAnimator.runtimeAnimatorController = characterData.animatorController;
            TB = tb;
        }
    }

    public void addHealthBar(HealthPanel statsPanel)
    {
        this.statsPanel = statsPanel;
        statsPanel.addCharacter(CharacterData);
    }

    public void addActionPanel(ActionPanel actionPanel)
    {
        this.actionPanel = actionPanel;
        actionPanel.addCharacter(this);
    }


    public override void ChooseAttack()
    {
        //Activamos el panel
        actionPanel.gameObject.SetActive(true);
    }

    public override void ChooseTarget()
    {
        MouseControl();
    }

    public override void ChooseState()
    {
        String state = FighterActionManager.Instance.attackInfo.FighterState.ToString(); 
        FighterAnimator.SetTrigger(state);
    }

    private void MouseControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1500, 1 << GameGlobals.LayerEnemy);
            if (hit)
            {
                FighterActionManager.Instance.FighterCursor.ChangeTargetByClick(hit.collider.gameObject);
                target = hit.collider.gameObject;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && target != null)
        {
            FighterActionManager.Instance.target=target.GetComponent<Fighter>();
            FighterActionManager.Instance.FighterCursor.gameObject.SetActive(false);
        }
    }

}
