using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BaseStatCharacter : BaseCharacter {

    public GameGlobals.CharacterType type;
    public int experience = 0;
    public int abilityPoints = 0;
    public Sprite face;
    

    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }

    public int AbilityPoints
    {
        get { return abilityPoints; }
        set { abilityPoints = value; }
    }

   
}
