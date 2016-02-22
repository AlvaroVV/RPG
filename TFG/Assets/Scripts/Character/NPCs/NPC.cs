using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class NPC : MonoBehaviour,Interactable {

    public string id;  
    public List<string> dialogue;
  

    public IEnumerator Interact()
    {
        dialogue = CSVReader.Instance.getDialogue(id);
        yield return InteractNPC();
    }

    public abstract IEnumerator InteractNPC();
    
}
