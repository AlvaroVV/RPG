using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class NPC : MonoBehaviour,Interactable {

    public string id;  
    public List<string> dialogue;
  
    void Awake()
    {
        //Cargamos el diálogo
        dialogue = CSVReader.Instance.getDialogue(id);     
    }


    public abstract void Interact();
    
}
