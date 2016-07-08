using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EigthChapter : AbstractChapter{

    private List<string[]> diálogo;
    private List<string[]> DialogoFinal;
    private List<string> ZackSentence;
    public List<GameObject> points;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameGlobals.TagPlayer))
            StartCoroutine(ExecuteChapter());
    }

    void Start()
    {
        ZackSentence = CSVReader.Instance.getSentences("Zack_Sentences_C8");
        diálogo = CSVReader.Instance.getDialogue("DialogoRipper");
        DialogoFinal = CSVReader.Instance.getDialogue("DiálogoFinal");
    }

    public override IEnumerator BodyChapter()
    {
        yield return ScriptingUtils.ShowDialogue(diálogo);
        yield return MovePlayerPositions(points);
        yield return GameGlobals.GetPlayerMovement().WaitForStartFight();
        yield return GameGlobals.GetPlayerMovement().WaitForFinishFight();
        yield return ScriptingUtils.ShowDialogue(DialogoFinal);
        yield return ScriptingUtils.DoAFadeIn();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public override IEnumerator InteractZack()
    {
        yield return ScriptingUtils.ShowSentences("Zack", ZackSentence);
    }

    
	
}
