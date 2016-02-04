using UnityEngine;
using System.Collections;

public class EquipmentData : ItemData
{
    public float defense = 10;
    public EquipmentType type;

    public enum EquipmentType
    {
        Helmet,
        Chest,
        Legs,
        Bracelet,

    }
	
}
