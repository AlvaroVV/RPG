using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FifthChapter : AbstractChapter {

    private List<string[]> dialogue;
    public ItemData itemData;

    // Use this for initialization
    void Start()
    {
        dialogue = CSVReader.Instance.getDialogue("Zack_Felix_Dialogue_C5");
    }

    public override IEnumerator BodyChapter()
    {
        yield return null;
    }

    public override IEnumerator InteractZack()
    {
        yield return ScriptingUtils.ShowDialogue(dialogue);
        GameGlobals.GetPlayerTeamController().AddItemData(itemData);
        ChangeChapter();
        Destroy(gameObject);
    }

    
	
	
}
