using UnityEngine;
using System.Collections;

public class HealthAttack : BaseAttack {

    public int Health;
    public int Mana;

    public override GameObject ApplyEffect(Fighter fighter, Fighter target)
    {
        target.Health(Health);
        target.UseMagic(Mana);
        GameObject textEffect = CombatTextManager.Instance.CreateHealthText(target.transform.position, Health);
        return textEffect;
    }

    public override bool canBeUsed(Fighter fighter)
    {
        if (fighter.FighterData.currentMP >= Mana)
            return true;
        else return false;
    }
}
