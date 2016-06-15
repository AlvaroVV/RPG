using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour {

    public Text textName;
    public Text HP_Current;
    public Text MP_Current;
    public Text HP_Total;
    public Text MP_Total;

    private BaseCharacter character;

    public void addCharacter(BaseCharacter character)
    {
        this.character = character;
        textName.text = character.CharacterName;
        HP_Total.text = character.HealthPoints.ToString();
        MP_Total.text = character.MagicPoints.ToString();
        HP_Current.text = character.currentHP.ToString();
        MP_Current.text = character.currentMP.ToString();
    }

    public void updateCurrentHP()
    {
        string health = (character.currentHP >= 0) ? character.currentHP.ToString() : "0";
        HP_Current.text = health;
    }

    public void updateCurrentMP()
    {
        string magic = (character.currentMP >= 0) ? character.currentMP.ToString() : "0";
        MP_Current.text = magic;
    }

}
