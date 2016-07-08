using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SixthChapter : AbstractChapter {

    private List<string> Zack_Sentence;
    private List<string> Sole_Sentence;
    private List<string> Felix_Sentence;
    private List<string> Felix_Sentence_Found;
    private string SoleSeUne;

    public GameObject Sole;
    public CharacterData soleData;
    public List<GameObject> points;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(GameGlobals.TagPlayer))
        {
            StartCoroutine(ExecuteChapter());
        }
    }

    // Use this for initialization
    void Start()
    {
        Zack_Sentence = CSVReader.Instance.getSentences("Zack_Sentence_C6");
        Sole_Sentence = CSVReader.Instance.getSentences("Sole_Sentences_C6");
        Felix_Sentence = CSVReader.Instance.getSentences("Felix_Sentence_C6");
        Felix_Sentence_Found = CSVReader.Instance.getSentences("Felix_Sentences_Found");
        SoleSeUne = CSVReader.Instance.GetWord("SoleJoin");
    }

    public override IEnumerator BodyChapter()
    {
        yield return ScriptingUtils.ShowSentences("Felix", Felix_Sentence_Found);
        yield return MovePlayerPositions(points);
        yield return ScriptingUtils.ShowSentences("Sole", Sole_Sentence);
        yield return ScriptingUtils.ShowSentences("Félix", Felix_Sentence);
        GameGlobals.GetPlayerTeamController().AddCharacter(soleData);
        Destroy(Sole);
        yield return ScriptingUtils.showInformation(SoleSeUne);
    }

    public override IEnumerator InteractZack()
    {
        yield return ScriptingUtils.ShowSentences("Zack", Zack_Sentence);
    }


}
