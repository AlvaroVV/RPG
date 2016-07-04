using UnityEngine;
using System.Collections;

public class Destroy_Object : MonoBehaviour {

    //Llamado cuando se acaba la animación.
    public void destroy()
    {
        Destroy(gameObject);
    }
}
