using UnityEngine;
using System;
using System.Collections.Generic;


public class EnemyData : BaseCharacter {

    //Lista de objetos que pueden soltar
    public int xp = 7;
    public int gold = 10;
    public List<ItemData> items;
 
    public int Xp { get { return xp; } set { xp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
}
