using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class DamageAttack : BaseAttack {

    public int damage;

    public override GameObject ApplyEffect(Fighter fighter, Fighter target)
    {
        int damage = CalculateDamage(fighter,target);
        target.SetDamage(damage);
        GameObject textEffect = CombatTextManager.Instance.CreateBounceText(target.transform.position,damage);
        return textEffect;
    }

	private int CalculateDamage(Fighter fighter, Fighter target)
    {
        float finalDamage = 0;
        switch (attackType)
        {
            case GameGlobals.AttackType.Attack:
                finalDamage = (damage + fighter.FighterData.AttackPower * 0.4f - target.FighterData.defensePower * 0.4f);
                break;
            case GameGlobals.AttackType.Magic:
                finalDamage = (damage + fighter.FighterData.MagicPower * 0.2f - target.FighterData.MagicDefense * 0.2f);
                break;
            default:
                return 0;
        }
        return (int)UnityEngine.Random.Range(finalDamage * 0.8f, finalDamage * 1.2f); 
    }   
    
}
