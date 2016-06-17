using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractChapter: MonoBehaviour
{
    public string ChapterName;
    public string NextChapterName;

    public string GetChapterName()
    {
        return ChapterName;
    }

    public IEnumerator ExecuteChapter()
    {
        //Situamos al jugador en estado Interact para que no pueda moverse mientras ocurre la cinemática
        GameGlobals.playerMovement.StateInteracting();

        //Ejecutamos la cinemática
        yield return BodyChapter();

        //Cambiamos de capítulo
        ChangeChapter();

        //Destruimos éste capítulo para que no siga haciendo efecto
        Destroy(gameObject);

        //Dejamos que el jugador vuelva a moverse
        GameGlobals.playerMovement.StateIdle();
        yield return null;
    }

    public abstract IEnumerator BodyChapter();



    public void ChangeChapter()
    {
        //Guardamos el siguiente capítulo por si el jugador Guarda, para que se inicialice una vez vuelva a entrar.
        GameSlotInfo.currentGameSlot.currentChapter = NextChapterName;
        GameObject chapterObj = Resources.Load("Chapters/" + NextChapterName) as GameObject;
        if (chapterObj != null)
        {
            Instantiate(chapterObj);
        }
        else
            Debug.LogError("No existe el capítulo -> " + NextChapterName);

    }

}

