using UnityEngine;
using System.Collections;

public class PotionMaxStrongData : ItemData {

    public int Strong_Increment;

    public override void ApplyEffect(CharacterData data)
    {
        data.attackPower += Strong_Increment;
    }

    public override void UseItem(ItemSlot itemSlot)
    {
        UIManager.Instance.CreateChooseCharacterPanel(itemSlot);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        return "Attack -> " + character.AttackPower;
    }

    public override bool ConditionToUse(CharacterData data)
    {
        return true;
    }
}
