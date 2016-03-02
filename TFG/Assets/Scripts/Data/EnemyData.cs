using UnityEngine;
using System;

public class EnemyData : BaseCharacter {

    public float hp = 10;
    public float hitCount = 1;
    public float damage = 2;
    public float agility = 2;
    public float xp = 7;
    public float gold = 10;
    public RuntimeAnimatorController AnimatorController;

    public float HP { get { return hp; } set { hp = value; } }
    public float HitCount { get { return hitCount; } set { hitCount = value; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public float Agility { get { return agility; } set { agility = value; } }
    public float Xp { get { return xp; } set { xp = value; } }
    public float Gold { get { return gold; } set { gold = value; } }
}
