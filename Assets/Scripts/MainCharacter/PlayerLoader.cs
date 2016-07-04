using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadCurrentPosition();
        LoadTeamAndInventory();
        LoadCurrentMap();
        LoadCurrentChapter();
	}

    public string GetActualMapName()
    {
       return  MapManager.Instance.GetActualMapName();
    }

    private void LoadCurrentMap()
    {
        MapManager.Instance.LoadMap(GameSlotInfo.currentGameSlot.currentMap);
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

    public void SaveGameSlotInfo()
    {
        GameSlotInfo.currentGameSlot.playerPositionX = transform.position.x;
        GameSlotInfo.currentGameSlot.playerPositionY = transform.position.y;
        GameSlotInfo.currentGameSlot.currentMap = GetActualMapName();
        SaveItems();
        SaveCharacters();
    }

    private void SaveItems()
    {
        GameSlotInfo.currentGameSlot.itemsNames = GetComponent<PlayerTeamController>().SaveItems();
    }

    private void SaveCharacters()
    {
        GameSlotInfo.currentGameSlot.characterStates = GetComponent<PlayerTeamController>().SaveCharacterDatas();
    }
}


	

