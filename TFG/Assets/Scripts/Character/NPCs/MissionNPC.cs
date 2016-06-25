using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MissionNPC : NPC
{
    public string id_accept;
    public ItemData itemNeed;
    public ItemData itemGiven;
   
    public List<string> sentenceAccept { get; set; }

    public override IEnumerator InteractNPC()
    {
        sentenceAccept = CSVReader.Instance.getSentences(id_accept);

        yield return ScriptingUtils.showNpcDialogue(this, true);

        if(GameGlobals.playerTeamController.LookForItemInventory(itemNeed))
        {
            yield return ScriptingUtils.ShowSentences(id_dialogue, sentenceAccept);

            GameGlobals.playerTeamController.AddItemData(itemGiven);
        }
    }
}
