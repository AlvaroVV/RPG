using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour {



	// Use this for initialization
	void Start () {
        LoadCurrentPosition();
        LoadTeamAndInventory();
        MapManager.Instance.LoadMap(GameSlotInfo.currentGameSlot.currentMap);
        LoadCurrentChapter();
	}

    private void LoadTeamAndInventory()
    {
        GetComponent<PlayerTeamController>().LoadTeamAndInventory();
    }

    private void LoadCurrentPosition()
    {
        transform.position = new Vector3(GameSlotInfo.currentGameSlot.playerPositionX, GameSlotInfo.currentGameSlot.playerPositionY, 0);
    }

    private void LoadCurrentChapter()
    {
        string ChapterName = GameSlotInfo.currentGameSlot.currentChapter;
        GameObject chapterObj = Resources.Load("Chapters/"+ChapterName) as GameObject;
        if (chapterObj != null)
        {
            GameObject chapter = Instantiate(chapterObj);

            if (ChapterName.Equals("FirstChapter"))
            {
                AbstractChapter chapterScript = chapter.GetComponent<AbstractChapter>();
                StartCoroutine(chapterScript.ExecuteChapter());      
            }
        }
        else
            Debug.LogError("No existe un capítulo con ese nombre -> " + ChapterName);
    }




	
}
