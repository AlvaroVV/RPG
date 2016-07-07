using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SecondChapter : AbstractChapter
{
    
    public List<GameObject> point1;

    List<string[]> dialogue = new List<string[]>();

    void OnTriggerEnter2D()
    {
        StartCoroutine(ExecuteChapter());
        dialogue = CSVReader.Instance.getDialogue("Felix_Zack_C2");
    }

    public override IEnumerator BodyChapter()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject point in point1)
        {
            yield return GameGlobals.GetPlayerMovement().MoveToPosition(point);
            yield return new WaitForSeconds(0.5f);
        }

        yield return ScriptingUtils.ShowDialogue(dialogue);
        yield return null;
    }
}
