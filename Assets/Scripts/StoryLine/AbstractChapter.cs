using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractChapter: MonoBehaviour
{
    public string ChapterName;
    public string NextChapterName;
    public List<string> ZackSentences { get; set; }

    void Start()
    {
        ZackSentences = new List<string>();
    }

    public string GetChapterName()
    {
        return ChapterName;
    }

    public IEnumerator ExecuteChapter()
    {
        //Situamos al jugador en estado Interact para que no pueda moverse mientras ocurre la cinemática
        GameGlobals.GetPlayerMovement().StateInteracting();

        //Ejecutamos la cinemática
        yield return BodyChapter();

        //Cambiamos de capítulo
        ChangeChapter();

        //Destruimos éste capítulo para que no siga haciendo efecto
        Destroy(gameObject);

        //Dejamos que el jugador vuelva a moverse
        GameGlobals.GetPlayerMovement().StateIdle();
        yield return null;
    }

    public abstract IEnumerator BodyChapter();

    public abstract IEnumerator InteractZack();


    public IEnumerator MovePlayerPositions(List<GameObject> points)
    {
        foreach (GameObject point in points)
        {
            yield return GameGlobals.GetPlayerMovement().MoveToPosition(point);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeChapter()
    {
        //Guardamos el siguiente capítulo por si el jugador Guarda, para que se inicialice una vez vuelva a entrar.
        GameSlotInfo.currentGameSlot.currentChapter = NextChapterName;
        GameObject chapterObj = Resources.Load("Chapters/" + NextChapterName) as GameObject;
        if (chapterObj != null)
        {
            GameObject chapter = Instantiate(chapterObj);
            ScriptingUtils.addChild(chapter, MapManager.Instance.gameObject);
            GameGlobals.GetPlayerLoader().SetCurrentChapter(chapter.GetComponent<AbstractChapter>());

        }
        else
        {
            GameGlobals.GetCameraControll().GoToBlackPanel();
            Debug.LogError("No existe el capítulo -> " + NextChapterName);
        }

    }

}

