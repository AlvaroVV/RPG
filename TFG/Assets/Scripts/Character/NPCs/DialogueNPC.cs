using UnityEngine;
using System.Collections;
using System;

public class DialogueNPC : NPC {


    public override IEnumerator InteractNPC()
    {
        yield return ScriptingUtils.showNpcDialogue(this,true);
    }

   
}
