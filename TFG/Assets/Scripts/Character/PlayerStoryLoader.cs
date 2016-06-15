using UnityEngine;
using System.Collections;

public class PlayerStoryLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
       LoadCurrentChapter();
	}

    private void LoadCurrentChapter()
    {
        string ChapterName = GameSlotInfo.currentGameSlot.currentChapter;
        GameObject chapterObj = Resources.Load("Chapters/"+ChapterName) as GameObject;
        if (chapterObj != null)
        {
            if (chapterObj.GetComponent<AbstractChapter>().AutoInstanciate)
            {
                GameObject chapter = Instantiate(chapterObj);
                AbstractChapter chapterScript = chapter.GetComponent<AbstractChapter>();

                if(ChapterName.Equals("FirstChapter"))
                    StartCoroutine(chapterScript.ExecuteChapter());
            }
        }
        else
            Debug.LogError("No existe un capítulo con ese nombre -> " + ChapterName);
    }


	
}
