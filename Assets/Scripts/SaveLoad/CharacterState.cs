using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class CharacterState  {
  
    public string CharacterName;
    public string CharacterPath;
    public int currentHP;
    public int currentMP;

    public int AbilityPoints;
    public int AttackPower;
    public int DefensePower;
    public int Evasion;
    public int Experience;
    public int HealthPoints;
    public int MagicDefense;
    public int MagicPoints;
    public int MagicPower;
    public int Speed;
    public string SpecialAttack;

    public void SaveCharacter(CharacterData data)
    {
        CharacterName = data.Name;

        HealthPoints = data.HealthPoints;
        currentHP = data.currentHP;
        MagicPoints = data.MagicPoints;
        currentMP = data.currentMP;
        AttackPower = data.AttackPower;
        DefensePower = data.DefensePower;
        MagicPower = data.MagicPower;
        MagicDefense = data.MagicDefense;
        Speed = data.Speed;
        Evasion = data.Evasion;
        Experience = data.Experience;
        AbilityPoints = data.AbilityPoints;
        if(data.specialAttack != null)
            SpecialAttack = data.specialAttack.NameAttack;
        
    }

    public void LoadCharacter(CharacterData characterData)
    {
        characterData.HealthPoints = HealthPoints;
        characterData.currentHP = currentHP;
        characterData.MagicPoints = MagicPoints;
        characterData.currentMP = currentMP;
        characterData.AttackPower = AttackPower;
        characterData.DefensePower = DefensePower;
        characterData.MagicPower = MagicPower;
        characterData.MagicDefense = MagicDefense;
        characterData.Speed = Speed;
        characterData.Evasion = Evasion;
        characterData.Experience = Experience;
        characterData.AbilityPoints = AbilityPoints;

        //characterData.specialAttack = Attacks;
    }

}
