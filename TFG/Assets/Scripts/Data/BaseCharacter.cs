using UnityEngine;
using System.Collections;

public class BaseCharacter: ScriptableObject  {

    public string name = "Nombre";
    public string description = "Descripcion";
    public RuntimeAnimatorController animatorController;

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public RuntimeAnimatorController AnimatorController { get { return animatorController; } set { animatorController = value; } }
}
