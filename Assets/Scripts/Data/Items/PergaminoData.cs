using UnityEngine;
using System.Collections;

public class PergaminoData : ItemData {

    public BaseAttack attackToLearn;

    public override void ApplyEffect(CharacterData data)
    {
        data.specialAttack = attackToLearn;
    }

    public override void UseItem(ItemSlot itemSlot)
    {
        UIManager.Instance.CreateChooseCharacterPanel(itemSlot);
    }

    public override string GetStadisticText(BaseCharacter character)
    {
        if (character.specialAttack == null)
            return "-----";
        else
            return character.specialAttack.NameAttack;
    }

    public override bool ConditionToUse(CharacterData data)
    {
        if (data.specialAttack != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
