using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class NPC : MonoBehaviour,Interactable {

    public string id;  
    [HideInInspector]public List<string> dialogue;
  

    public IEnumerator Interact()
    {
        dialogue = CSVReader.Instance.getDialogue(id);
        yield return null; // Para que al pulsar el Space al comenzar no lo tome a la vez
        yield return InteractNPC();
    }

    public abstract IEnumerator InteractNPC();
    
}
