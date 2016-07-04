using UnityEngine;
using System.Collections;
using System;


public class ItemData : ScriptableObject
{
    public string id = "Item";
    public string description = "Description";
    public Sprite image;
    public bool NeedsPanel = false;
    public string ItemPath = "";

    public string Description { get { return description; } set { description = value; } }
    public string Id { get { return id; } set { id = value; } }
    public Sprite Image { get { return image; } set { this.image = value; } }


    public virtual void ApplyEffect(CharacterData data)
    {
        Debug.Log("Aplicando Efecto");
    }

    public virtual void UseItem(ItemSlot itemSlot)
    {
        Debug.Log("Usando " + id);

    }

    public virtual string GetStadisticText(BaseCharacter character)
    {
        return "StatisticText";
    }

    public virtual bool ConditionToUse(CharacterData data)
    {
        return true;
    }


}
  
