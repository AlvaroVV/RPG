using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class CharacterState  {
    public CharacterData OriginalData;

    public string CharacterName;

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

    public List<BaseAttack> Attacks;

    public void SaveCharacter(CharacterData data)
    {
        OriginalData = data;

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
        Attacks = data.Attacks;
        
    }

    public void LoadCharacter()
    {
        OriginalData.HealthPoints = HealthPoints;
        OriginalData.currentHP = currentHP;
        OriginalData.MagicPoints = MagicPoints;
        OriginalData.currentMP = currentMP;
        OriginalData.AttackPower = AttackPower;
        OriginalData.DefensePower = DefensePower;
        OriginalData.MagicPower = MagicPower;
        OriginalData.MagicDefense = MagicDefense;
        OriginalData.Speed = Speed;
        OriginalData.Evasion = Evasion;
        OriginalData.Experience = Experience;
        OriginalData.AbilityPoints = AbilityPoints;

        OriginalData.Attacks = Attacks;
    }

}
