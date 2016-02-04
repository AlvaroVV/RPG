using UnityEngine;
using System.Collections;

public class BaseCharacter  {

    public string name = "Nombre";
    public string description = "Descripcion";

    public string Nombre {
        get { return name; }
        set { name = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
