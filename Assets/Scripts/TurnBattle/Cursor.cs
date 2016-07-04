using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cursor : MonoBehaviour {

    public Fighter target { get; set; }

    public void ChangeTarget(Fighter newTarget)
    {
        target = newTarget;
        transform.position = target.gameObject.transform.position;
    }

    public void ChangeTargetByClick(GameObject target)
    {
        Fighter fighter = target.GetComponent<Fighter>();
        transform.position = target.gameObject.transform.position;
        this.target = fighter;
    }

    
}
