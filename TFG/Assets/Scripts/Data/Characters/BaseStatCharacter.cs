using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BaseStatCharacter : BaseCharacter {

    public int healthPoints = 75;
    public int currentHP = 60;
    public int magicPoints = 20;
    public int currentMP = 15;
    public GameGlobals.CharacterType type;
    public int experience = 0;
    public int abilityPoints = 0;
    public int attackPower = 10;
    public int defensePower= 5;
    public int magicPower = 5;
    public int magicDefense = 5;
    public int speed = 10;
    public int evasion = 5;
    public Sprite face;
    public List<CharacterAttack> Attacks;

    public int HealthPoints
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }

    public int MagicPoints
    {
        get { return magicPoints; }
        set { magicPoints = value; }
    }

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

    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    public int DefensePower
    {
        get { return defensePower; }
        set { defensePower = value; }
    }

    public int MagicPower
    {
        get { return magicPower; }
        set { magicPower = value; }
    }

    public int MagicDefense
    {
        get { return magicDefense; }
        set { magicDefense = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }
}
