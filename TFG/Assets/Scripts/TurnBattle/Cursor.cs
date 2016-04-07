using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    private Fighter target;

    public void ChangeTarget(Fighter newTarget)
    {
        target = newTarget;
        transform.position = target.gameObject.transform.position;
    }

    public void ChangeTargetByClick(GameObject gameObject)
    {
        Fighter fighter = gameObject.GetComponent<Fighter>();
        target = fighter;
        transform.position = target.gameObject.transform.position;
    }
}
