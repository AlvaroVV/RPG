using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ItemData : ScriptableObject
{
    public string id = "Item";
    public string description = "Description";
    public Sprite image;
    public bool NeedsPanel = false;

    public string Description { get { return description; } set { description = value; } }
    public string Id { get { return id; } set { id = value; } }
    public Sprite Image { get { return image; } set { this.image = value; } }

    public BaseCharacter Character { get; set; }

    public virtual void UseItem()
    {
        Debug.Log("Usando " + id);
    }

    public virtual string GetStadisticText(BaseCharacter character)
    {
        return "StatisticText";
    }

    public bool CanBeUsed(BaseCharacter character)
    {
        //Si Character es null, quiere decir que es un objeto que no necesita de objetivo para ser usado
        if (character != null)
        {
            this.Character = character;
            return ConditionToUse();
        }
        else
            return true;
    }

    public virtual bool ConditionToUse()
    {
        return true;
    }


}
  
