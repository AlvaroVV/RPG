using UnityEngine;
using System.Collections;
using System;

public class CharacterFighter : Fighter {

    private BaseStatCharacter characterData;
    private HealthPanel statsPanel;
    private ActionPanel actionPanel;

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

    public override void setActivePanelAction(bool activate)
    {
        actionPanel.gameObject.SetActive(activate);
    }

}
