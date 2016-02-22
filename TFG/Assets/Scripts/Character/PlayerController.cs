using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class PlayerController : PlayerMovement {

    private List<BaseStatCharacter> team;
    //PlayerInventory inventory;

    public override void Awake()
    {
        base.Awake();
        team = new List<BaseStatCharacter>();

        team.Add(new BaseStatCharacter("Felix"));
        team.Add(new BaseStatCharacter("Nadia"));
        team.Add(new BaseStatCharacter("Sole"));
        team.Add(new BaseStatCharacter("Piers"));
    }

    public List<BaseStatCharacter> getTeam()
    {       
        return team;
    }

    
}
