using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class PlayerTeam: MonoBehaviour {

    public List<WeaponData> team;
    //PlayerInventory inventory;

    void Awake()
    {
       
    }

    public List<WeaponData> getTeam()
    {       
        return team;
    }

    
}
