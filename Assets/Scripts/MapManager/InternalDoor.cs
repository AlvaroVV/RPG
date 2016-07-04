using UnityEngine;
using System.Collections;

public class InternalDoor : MonoBehaviour {

    public string InternalMapName;
    public GameObject ExitPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
           StartCoroutine( MapManager.Instance.UseInternalDoor(InternalMapName, ExitPoint));

        }


    }
}
