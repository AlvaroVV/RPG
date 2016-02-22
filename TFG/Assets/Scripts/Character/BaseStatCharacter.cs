using UnityEngine;
using System.Collections;

public class BaseStatCharacter : BaseCharacter {

    public float health;
    public float intellect;
    public float spirit;
    public float speed;

    public BaseStatCharacter(string name)
    {
        this.name = name;
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }

    public float Spirit
    {
        get { return spirit; }
        set { spirit = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

}
