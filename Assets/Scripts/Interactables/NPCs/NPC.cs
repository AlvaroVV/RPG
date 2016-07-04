using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class NPC : MonoBehaviour,Interactable {

    public string NPC_name;
    public string id_dialogue;  
    [HideInInspector]public List<string> dialogue;
  

    public IEnumerator Interact()
    {
        dialogue = CSVReader.Instance.getSentences(id_dialogue);
        yield return null; // Para que al pulsar el Space al comenzar no lo tome a la vez
        yield return InteractNPC();
    }

    public abstract IEnumerator InteractNPC();
    
}
