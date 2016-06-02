using UnityEngine;
using System.Collections;

public class ChooseCharacterManager : MonoBehaviour {

    public ItemSlot itemSlot { get; set; }

    private static ChooseCharacterManager instance;

    public static ChooseCharacterManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public void ChargeSlot(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;

        if (this.itemSlot.getItem().NeedsPanel)
            UIManager.Instance.CreateChooseCharacterPanel(this.itemSlot.getItem());
        else
            this.itemSlot.UseItem(null);
    }


    public void ApplyEffectOnCharacter(BaseCharacter character)
    {
            itemSlot.UseItem(character);
    }
}
