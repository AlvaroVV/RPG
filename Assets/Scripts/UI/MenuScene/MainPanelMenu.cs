using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanelMenu : MonoBehaviour {

    public static MainPanelMenu Instance
    {
        get
        {
            return instance;
        }
    }

    //Panels
    public GameObject GameNamePanel;
    public GameObject PanelMenu;
    public GameObject NewGameMenu;
    public GameObject GameSlotsMenu;
    public GameObject ContinuePanel;

    //Atributes
    public Text slotNameText;
    public Text slotNameTextContinue;

    private static  MainPanelMenu instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SaveLoadManager.Load();
    }

    public void ClickNewGame()
    {
        NewGameMenu.SetActive(true);
        SaveLoadManager.NewGameSlot();
    }

    public void StartNewGame()
    {
        string name = slotNameText.text;
        if (!name.Equals(""))
        {
            GameSlotInfo.currentGameSlot.gameSlotName = name;
            SceneManager.LoadScene(1);
        }
    }

    public void ClickStart()
    {
        PanelMenu.SetActive(false);
        GameSlotsMenu.SetActive(true);
    }

    public void ClickContinue()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickDelete()
    {
        Debug.Log(GameSlotInfo.currentGameSlot.gameSlotName);
        SaveLoadManager.DeleteGameSlot();
        MenuContinue.Instance.RestartPanel();
        ContinuePanel.SetActive(false);
        PanelMenu.SetActive(true);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ButtonBack()
    {
        NewGameMenu.SetActive(false);
        GameSlotsMenu.SetActive(false);
        PanelMenu.SetActive(true);
    }

    public IEnumerator StartMenu()
    {
        yield return new WaitForSeconds(1.5f);
        GameNamePanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PanelMenu.SetActive(true);

    }

    public IEnumerator WaitForKeyPressed(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }

        yield return null;
    }

}
