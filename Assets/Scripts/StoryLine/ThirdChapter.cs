using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ThirdChapter : AbstractChapter
{

    public ItemData itemNeeded;
    private List<string> sentenceGive;
    private List<string[]> firstDialogue;

    void Start()
    {
        ZackSentences = CSVReader.Instance.getSentences("Zack_" + ChapterName);
        sentenceGive = new List<string>();
        sentenceGive = CSVReader.Instance.getSentences("Zack_Given_C3");
        firstDialogue = CSVReader.Instance.getDialogue("Felix_Zack_C3");
    }

    public override IEnumerator BodyChapter()
    {
        yield return null;
    }

    public override IEnumerator InteractZack()
    {           
        sentenceGive = CSVReader.Instance.getSentences("Zack_Given_C3");
        if(GameGlobals.GetPlayerTeamController().LookForItemInventory(itemNeeded))
        {
            yield return ScriptingUtils.ShowSentences("Zack", sentenceGive);
            yield return ScriptingUtils.ShowDialogue(firstDialogue);
            ChangeChapter();
            Destroy(gameObject);
        }
        else
            yield return ScriptingUtils.ShowSentences("Zack", ZackSentences);
    }

}
