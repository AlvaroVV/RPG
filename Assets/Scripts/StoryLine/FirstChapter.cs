using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FirstChapter : AbstractChapter
{
    public GameObject initialPoint;
    public GameObject SoulFlame;

    List<string> senteceDream = new List<string>();
    List<string[]> dialogueDream = new List<string[]>();
    List<string> sentenceWakeUp = new List<string>();

    void Start()
    {
        senteceDream = CSVReader.Instance.getSentences("Sentence_Dream1");
        dialogueDream = CSVReader.Instance.getDialogue("Dream1");
        sentenceWakeUp = CSVReader.Instance.getSentences("WakenUp1");
    }

    public override IEnumerator BodyChapter()
    { 
        
        GameObject blackPanel = GameGlobals.GetCameraControll().GoToBlackPanel();

        yield return new WaitForSeconds(2);

        yield return ScriptingUtils.ShowSentences("Felix", senteceDream);

        GameObject soul = Instantiate(SoulFlame) as GameObject;

        yield return new WaitForSeconds(2);

        yield return ScriptingUtils.ShowDialogue(dialogueDream);

        SetPlayerPosition();

        yield return ScriptingUtils.DoAFadeIn();

        Destroy(soul);
        MapManager.Instance.GoToMainMap();

        StartCoroutine(ScriptingUtils.DoAFadeOut());

        yield return GameGlobals.GetPlayerAnimManager().Estado_durmiendo();

        yield return ScriptingUtils.ShowSentences("Felix", sentenceWakeUp);

        yield return GameGlobals.GetPlayerAnimManager().Estado_wakingUp();

        Destroy(blackPanel);

    }

    private void SetPlayerPosition()
    {
        GameGlobals.GetPlayer().transform.position = initialPoint.transform.position;
    }

}
