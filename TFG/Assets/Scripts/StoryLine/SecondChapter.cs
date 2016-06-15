using UnityEngine;
using System.Collections;
using System;


public class SecondChapter : AbstractChapter
{
    void OnTriggerEnter2D()
    {
        StartCoroutine(BodyChapter());
    }

    public override IEnumerator BodyChapter()
    {
        Debug.Log("EMPIEZA CAP 2");
        yield return null;
    }
}
