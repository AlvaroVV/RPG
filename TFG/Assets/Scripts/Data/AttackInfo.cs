using UnityEngine;
using System.Collections;

public class AttackInfo : ScriptableObject {

    public string idAttack = "sword";
    public string descriptionAttack = "description sword attack";
    public int damage = 10; //Porcentaje de daño para la formula del ataque
    public GameObject animation; //Animación del ataque
    public GameGlobals.AttackType fighterState; //Estado del Fighter: Attack or Magic

    public string Id { get { return CSVReader.Instance.GetWord(idAttack); } set { idAttack = value; } }

    public string Description
    {
        get { return CSVReader.Instance.GetWord(idAttack + "_info"); }
        set { descriptionAttack = value; }
    }

    public int Damage { get { return damage; } set { damage = value; } }

    public GameObject Animation {
        get { return animation; }
        set { animation = value; }
    }

    public GameGlobals.AttackType FighterState {
        get { return fighterState; }
        set { fighterState = value; }
    }

}
