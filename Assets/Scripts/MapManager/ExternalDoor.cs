using UnityEngine;
using System.Collections;


public class ExternalDoor : MonoBehaviour {

    public string MapName;
    public string DoorName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
             MapManager.Instance.UseExternalDoorCoroutine(MapName, DoorName);
         
        }
                    
    
    }
}
