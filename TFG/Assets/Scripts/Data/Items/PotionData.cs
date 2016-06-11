using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PotionData : ItemData {

    public int Hp_restore;

    void OnEnable()
    {
        ItemPath = "Items/" + id;
    }

    public override void UseItem()
    {
        Character.RestoreHP(Hp_restore);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        return "HP " + character.currentHP + "/" + character.healthPoints;
    }

    public override bool ConditionToUse()
    {
        if (Character.currentHP + Hp_restore > Character.healthPoints)
        {
            Debug.Log(Character.Name + " no puede recuperar más HP");
            return false;
        }
        else
        {
            return true;
        }
    }

}
