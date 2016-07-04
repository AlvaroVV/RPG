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
        if (data.currentHP + Hp_restore > data.healthPoints)
        {
            Debug.Log(data.Name + " no puede recuperar más HP");
            return false;
        }
        else
        {
            return true;
        }
    }

}
