using UnityEngine;
using System.Collections;
using System;

public class DialogueNPC : NPC {


    public override void Interact()
    {       
        
       StartCoroutine(actionNPC());
    }

    public  IEnumerator actionNPC()
    {
        UIManager.Instance.writeTitle(id);

        foreach (string d in dialogue)
        {
            yield return StartCoroutine(talk(d));
            yield return null;
        }

        UIManager.Instance.closeDialogWindow();
    }


    IEnumerator talk(string dialogue)
    {

        //Debug.Log(dialogue);
        UIManager.Instance.showDialog(dialogue);
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
