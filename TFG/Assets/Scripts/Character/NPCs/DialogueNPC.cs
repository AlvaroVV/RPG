using UnityEngine;
using System.Collections;
using System;

public class DialogueNPC : NPC {


    public override void InteractNPC()
    {
       StartCoroutine(ScriptingUtils.showNpcDialogue(this,true));
    }

    public  IEnumerator actionNPC()
    {
        foreach (string d in dialogue)
        {
            yield return StartCoroutine(talk(d));
            yield return null;
        }

    }


    IEnumerator talk(string dialogue)
    {

        //Debug.Log(dialogue);
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
