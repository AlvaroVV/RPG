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


    public void addCharacter(BaseStatCharacter character)
    {
        textName.text = character.name;
        HP_Total.text = character.HealthPoints.ToString();
        MP_Total.text = character.MagicPoints.ToString();
        HP_Current.text = character.currentHP.ToString();
        MP_Current.text = character.currentMP.ToString();
    }
	
}
