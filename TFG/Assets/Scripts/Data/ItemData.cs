using UnityEngine;
using System.Collections;

public class ItemData : ScriptableObject {

    #region Public Item
    public string id = "Item";
    public string description = "Description";
    public float min_lvl = 1;
    public bool equipable = true;
    #endregion

    public float Lvl { get { return min_lvl; } set { min_lvl = value; } }
    public string Description { get { return description; } set { description = value; } }
    public string Id { get { return id; } set { id = value; } }
    public bool Equipable { get { return equipable; } set { equipable = value; } }
}
