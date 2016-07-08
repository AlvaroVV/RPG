using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PotionHealthData : ItemData {

    public int Hp_restore;

    public override void ApplyEffect(CharacterData data)
    {
         data.RestoreHP(Hp_restore);
    }

    public override void UseItem(ItemSlot itemSlot)
    {
        UIManager.Instance.CreateChooseCharacterPanel(itemSlot);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        return "HP " + character.currentHP + "/" + character.healthPoints;
    }

    public override bool ConditionToUse(CharacterData data)
    {
        if (data.currentHP  >= data.healthPoints)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
