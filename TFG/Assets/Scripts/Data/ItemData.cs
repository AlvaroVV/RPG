using UnityEngine;
using System.Collections;

public class ItemData : ScriptableObject {

    public string Name;
    public float id;
    public float lvl = 1;

    public float Lvl { get { return lvl; } set { lvl = value; } }

}
