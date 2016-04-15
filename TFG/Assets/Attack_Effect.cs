using UnityEngine;
using System.Collections;

public class Attack_Effect : MonoBehaviour {

    //Llamado cuando se acaba la animación.
    public void finishEffect()
    {
        Destroy(gameObject);
    }
}
