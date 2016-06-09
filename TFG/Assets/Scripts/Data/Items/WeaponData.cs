using System;
using UnityEngine;

[Serializable]
public class WeaponData : ItemData
{
    public float damage = 10;
    public float speed = 5;
    public WeaponType type;

    public enum WeaponType
    {
        Sword,
        Axe,
        Spear,
        Dagger,
    }

    public float Damage{ get{return damage;} set{ damage = value;}}
    public float Speed { get { return speed; } set { speed = value; } }
    public WeaponType Weapon_type { get { return type; } set { type = value; } }

}
