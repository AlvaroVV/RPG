using UnityEngine;
using System.Collections;

public class PotionManaData : ItemData
{

    public int Mana_restore;

    public override void ApplyEffect(CharacterData data)
    {
        data.RestoreMP(Mana_restore);
    }

    public override void UseItem(ItemSlot itemSlot)
    {
        UIManager.Instance.CreateChooseCharacterPanel(itemSlot);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        return "MP " + character.currentMP + "/" + character.magicPoints;
    }

    public override bool ConditionToUse(CharacterData data)
    {
        if (data.currentMP >= data.magicPoints)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
