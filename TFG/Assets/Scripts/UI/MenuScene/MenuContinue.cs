using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuContinue : MonoBehaviour {

    public GameObject button;
    public GameObject panelButtons;

    void Start()
    {
        Debug.Log("Start");
        CreateButtonSlots();
    }
    
    private void CreateButtonSlots()
    {
        GameSlotInfo[] infos = SaveLoadManager.gamesSlots.gameSlotsInfo;
        for (int i = 0; i< infos.Length -1; i++)
        {
            GameObject boton = Instantiate(button) as GameObject;
            boton.GetComponentInChildren<Text>().text = infos[i].gameSlotName;

            Button buttonTemp = boton.GetComponent<Button>();
            GameSlotInfo info = infos[i];
            buttonTemp.onClick.AddListener(() => setGameSlotInfo(info));

            ScriptingUtils.addChild(boton, panelButtons);
            
        }
    }

    private void setGameSlotInfo(GameSlotInfo info)
    {
        GameSlotInfo.currentGameSlot = info;
        SceneManager.LoadScene(1);
        Debug.Log(info.gameSlotName);
    }

    
}
