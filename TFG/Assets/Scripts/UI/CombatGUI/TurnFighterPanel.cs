using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnFighterPanel : MonoBehaviour {

    public Text FighterName;
    public Image FighterImage = null;

    private Fighter fighter;
    
    public void addFighter(Fighter fighter)
    {
        this.fighter = fighter;
        FighterName.text = fighter.FighterName;
        if (fighter.FighterImage != null)
            FighterImage.sprite = fighter.FighterImage;
        else
            FighterImage.gameObject.SetActive(false);
    }
}
