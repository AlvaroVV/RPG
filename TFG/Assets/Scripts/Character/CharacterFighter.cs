using UnityEngine;
using System.Collections;

public class CharacterFighter : MonoBehaviour {

    private Animator anim;
    private BaseStatCharacter characterData;
    private HealthPanel healthPanel;

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
}
