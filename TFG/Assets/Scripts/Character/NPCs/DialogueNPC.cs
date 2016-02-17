using UnityEngine;
using System.Collections;
using System;

public class DialogueNPC : NPC {
    

    public override IEnumerator actionNPC()
    {
        foreach (string d in dialogue)
        {
            yield return StartCoroutine(talk(d));
        }

    }

    IEnumerator talk(string dialogue)
    {
        Debug.Log(dialogue);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
    }
}
