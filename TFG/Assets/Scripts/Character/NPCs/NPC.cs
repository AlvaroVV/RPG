using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class NPC : MonoBehaviour,Interactable {

    public string id;  
    public List<string> dialogue;
  
    
    public void Interact()
    {
        dialogue = CSVReader.Instance.getDialogue(id);
        InteractNPC();
    }

    public abstract void InteractNPC();
    
}
