using UnityEngine;
using System.Collections.Generic;
using System;


public class BaseCharacter: ScriptableObject  {

    public string CharacterName = "Nombre";
    public string description = "Descripcion";
    //Stats
    public int healthPoints = 75;
    public int currentHP = 75;
    public int magicPoints = 20;
    public int currentMP = 15;
    public int attackPower = 10;
    public int defensePower = 5;
    public int magicPower = 5;
    public int magicDefense = 5;
    public int speed = 10;
    public int evasion = 5;

    //Attacks
    public BaseAttack normalAttack;
    public BaseAttack specialAttack;

    //Animator
    public RuntimeAnimatorController animatorController;

    public string Name {
        get { return CharacterName; }
        set { CharacterName = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

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

    public RuntimeAnimatorController AnimatorController { get { return animatorController; } set { animatorController = value; } }

    public void RestoreHP(int hp)
    {
        if (currentHP + hp > healthPoints)
            currentHP = healthPoints;
        else
            currentHP += hp;
       
    }

    public void RestoreMP(int mp)
    {
        if (currentMP + mp > magicPoints)
            currentMP = magicPoints;
        else
            currentMP += mp;
    }
}
