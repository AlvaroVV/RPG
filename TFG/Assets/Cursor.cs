using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    private Fighter target;

    public void ChangeTarget(Fighter newTarget)
    {
        target = newTarget;
        transform.position = target.gameObject.transform.position;
    }
}
