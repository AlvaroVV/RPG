using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour {

    private AbstractChapter currentChapter;

	// Use this for initialization
	void Start () {
        LoadCurrentPosition();
        LoadTeamAndInventory();
        LoadCurrentMap();
        LoadCurrentChapter();
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
            ScriptingUtils.addChild(chapter, MapManager.Instance.gameObject);
            currentChapter = chapter.GetComponent<AbstractChapter>();
            if (ChapterName.Equals("FirstChapter"))
            {
                StartCoroutine(currentChapter.ExecuteChapter());      
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

    private string GetActualMapName()
    {
        return MapManager.Instance.GetActualMapName();
    }

    private void SaveItems()
    {
        GameSlotInfo.currentGameSlot.itemsNames = GetComponent<PlayerTeamController>().SaveItems();
    }

    private void SaveCharacters()
    {
        GameSlotInfo.currentGameSlot.characterStates = GetComponent<PlayerTeamController>().SaveCharacterDatas();
    }

    public void SetCurrentChapter(AbstractChapter chapter)
    {
        currentChapter = chapter;
    }

    public AbstractChapter GetCurrentChapter()
    {
        return currentChapter;
    }
}


	

