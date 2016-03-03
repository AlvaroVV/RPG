using UnityEngine;
using System;
using System.Collections.Generic;


public class EnemyData : BaseCharacter {

    public int hp = 10;
    public int hitCount = 1;
    public int damage = 2;
    public int defense = 3;
    public int agility = 2;
    public int xp = 7;
    public int gold = 10;
    public RuntimeAnimatorController animatorController;
    public List<EnemyAttack> attacks;
 

    public int HP { get { return hp; } set { hp = value; } }
    public int HitCount { get { return hitCount; } set { hitCount = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public int Agility { get { return agility; } set { agility = value; } }
    public int Xp { get { return xp; } set { xp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public RuntimeAnimatorController AnimatorController { get { return animatorController; } set { animatorController = value; } }
}
