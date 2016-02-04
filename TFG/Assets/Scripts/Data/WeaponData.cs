using UnityEngine;

public class WeaponData : ItemData
{

    public float damage = 10;
    public WeaponType type;

    public enum WeaponType
    {
        Sword,
        Axe,
        Spear,
        Dagger,
    }

    public float Damage{ get{return damage;} set{ damage = value;}}
    
    
}
