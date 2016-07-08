using UnityEngine;
using System.Collections;

public class PotionMaxMana : ItemData {

    public int Mana_Increment;

    public override void ApplyEffect(CharacterData data)
    {
        data.MagicPoints += Mana_Increment;
    }

    public override void UseItem(ItemSlot itemSlot)
    {
        UIManager.Instance.CreateChooseCharacterPanel(itemSlot);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        return "MP " + character.currentMP + "/" + character.MagicPoints;
    }

    public override bool ConditionToUse(CharacterData data)
    {
        return true;
    }
}
