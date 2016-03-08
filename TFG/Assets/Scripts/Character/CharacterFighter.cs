using UnityEngine;
using System.Collections;

public class CharacterFighter : MonoBehaviour {

    private Animator anim;
    private BaseStatCharacter characterData;
    private HealthPanel statsPanel;
    private ActionPanel actionPanel;

    public void setCharacterProperties(BaseStatCharacter characterData)
    {
        if (characterData != null)
        {
            anim = GetComponentInChildren<Animator>();
            this.characterData = characterData;
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

    public Animator getAnim()
    {
        return anim;
    }

    public BaseStatCharacter getBaseStatCharacter()
    {
        return characterData;
    }
}
