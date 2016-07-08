using UnityEngine;
using System.Collections;

public class PotionMaxHealthData : ItemData {

    public int Hp_Increment;

    public override void ApplyEffect(CharacterData data)
    {
        data.healthPoints += Hp_Increment;
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
        return true;
    }
}
