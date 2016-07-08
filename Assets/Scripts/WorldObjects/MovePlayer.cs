using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePlayer : MonoBehaviour {

    public string Id_Sentence;
    public GameObject point;
    private List<string> sentence;

    void Start()
    {
        sentence = CSVReader.Instance.getSentences(Id_Sentence);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(GameGlobals.TagPlayer))
        {
            StartCoroutine(MovePosition());
        }
    }

    private IEnumerator MovePosition()
    {
        GameGlobals.GetPlayerMovement().StateInteracting();
        point.transform.position = new Vector2(point.transform.position.x, GameGlobals.GetPlayer().transform.position.y);
        yield return ScriptingUtils.ShowSentences("Felix", sentence);
        yield return GameGlobals.GetPlayerMovement().MoveToPosition(point);
        GameGlobals.GetPlayerMovement().StateIdle();
    }
}
