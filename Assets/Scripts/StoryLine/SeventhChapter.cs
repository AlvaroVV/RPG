using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SeventhChapter : AbstractChapter {

    private List<string> Sole_Sentence_Wrong;
    private List<string> Sole_Sentence_Good;
    public ItemData itemNeed;
    public GameObject Goblin;

    void Start()
    {
        Sole_Sentence_Wrong = CSVReader.Instance.getSentences("Zack_Sentence_Wrong_C7");
        Sole_Sentence_Good = CSVReader.Instance.getSentences("Zack_Sentence_Good_C7");
    }

    public override IEnumerator BodyChapter()
    {
        yield return null;
    }

    public override IEnumerator InteractZack()
    {
        if (GameGlobals.GetPlayerTeamController().LookForItemInventory(itemNeed))
        {
            yield return ScriptingUtils.ShowSentences("Zack", Sole_Sentence_Good);
            ChangeChapter();
            Destroy(gameObject);
        }
        else
        {
            yield return ScriptingUtils.ShowSentences("Zack", Sole_Sentence_Wrong);
        }
    }



}
