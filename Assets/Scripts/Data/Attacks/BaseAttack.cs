using UnityEngine;
using System.Collections;
using System;

[Serializable]
public abstract class BaseAttack : ScriptableObject {

    public string idAttack = "sword";
    public string descriptionAttack = "description sword attack";
    public GameObject animation; //Animación del ataque
    public GameGlobals.AttackType attackType; //Estado del Fighter: Attack or Magic

    public string Id { get { return CSVReader.Instance.GetWord(idAttack); } set { idAttack = value; } }

    public string Description
    {
        get { return CSVReader.Instance.GetWord(idAttack + "_info"); }
        set { descriptionAttack = value; }
    }

    public GameObject Animation {
        get { return animation; }
        set { animation = value; }
    }

    public GameGlobals.AttackType FighterState {
        get { return attackType; }
        set { attackType = value; }
    }

    public abstract GameObject ApplyEffect(Fighter fighter, Fighter target);

}
