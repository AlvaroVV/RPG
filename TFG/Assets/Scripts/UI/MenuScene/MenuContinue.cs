using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuContinue : MonoBehaviour {

    public static MenuContinue Instance
    {
        get
        {
            return instance;
        }
    }
    private static MenuContinue instance;

    public GameObject button;
    public GameObject panelButtons;

    private List<GameObject> buttons = new List<GameObject>(); 

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateButtonSlots();
    }
    
    private void CreateButtonSlots()
    {
        GameSlotInfo[] infos = SaveLoadManager.gamesSlots.gameSlotsInfo;
        for (int i = 0; i< infos.Length; i++)
        {
            GameObject boton = Instantiate(button) as GameObject;
            boton.GetComponentInChildren<Text>().text = infos[i].gameSlotName;

            Button buttonTemp = boton.GetComponent<Button>();
            GameSlotInfo info = infos[i];
            buttonTemp.onClick.AddListener(() => setGameSlotInfo(info));

            ScriptingUtils.addChild(boton, panelButtons);
            buttons.Add(boton);
        }
    }

    private void setGameSlotInfo(GameSlotInfo info)
    {
        GameSlotInfo.currentGameSlot = info;
        MainPanelMenu.Instance.GameSlotsMenu.SetActive(false);
        if (info.gameSlotName.Equals(""))
        {
            MainPanelMenu.Instance.ClickNewGame();
        }
        else
        {
            MainPanelMenu.Instance.ContinuePanel.SetActive(true);
        }
    }

    public void RestartPanel()
    {
        foreach (GameObject button in buttons)
            Destroy(button);
        CreateButtonSlots();

    }
}
