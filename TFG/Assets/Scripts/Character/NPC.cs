using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour {

    public string id;
    private List<string> dialogue;

    void Awake()
    {
        //Cargamos el diálogo
        dialogue = CSVReader.Instance.getDialogue(id);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
