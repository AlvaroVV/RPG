using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ForthChapter : AbstractChapter {

    private List<string> firstSentence;
    private List<string> secondSentence;
    public List<GameObject> points;
    public GameObject finalPoint;
    public GameObject enemie;

    void Start()
    {
        firstSentence = CSVReader.Instance.getSentences("Felix_Sentence1_C4");
        secondSentence = CSVReader.Instance.getSentences("Felix_Sentence2_C4");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(GameGlobals.TagPlayer))
        {
            StartCoroutine(ExecuteChapter());
        }
    }

    public override IEnumerator BodyChapter()
    {
        enemie.SetActive(true);
        yield return MovePlayerPositions(points);
        yield return ScriptingUtils.ShowSentences("Felix", firstSentence);
        yield return GameGlobals.GetPlayerMovement().MoveToPosition(finalPoint);
        yield return GameGlobals.GetPlayerMovement().WaitForStartFight();
        yield return GameGlobals.GetPlayerMovement().WaitForFinishFight();
        yield return ScriptingUtils.ShowSentences("Felix", secondSentence);
    }

    public override IEnumerator InteractZack()
    {
        Debug.Log("Capitulo 4");
        yield return null;
    }
}
