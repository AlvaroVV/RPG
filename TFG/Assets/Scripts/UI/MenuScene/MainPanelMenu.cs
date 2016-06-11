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
    public GameObject ContinueMenu;

    //Atributes
    public Text slotNameText;

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
        PanelMenu.SetActive(false);
        NewGameMenu.SetActive(true);
        SaveLoadManager.NewSlot();
    }

    public void StartNewGame()
    {
        string name = slotNameText.text;
        GameSlotInfo.currentGameSlot.gameSlotName = name;
        SceneManager.LoadScene(1);
    }

    public void ClickContinue()
    {
        PanelMenu.SetActive(false);
        ContinueMenu.SetActive(true);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ButtonBack()
    {
        NewGameMenu.SetActive(false);
        ContinueMenu.SetActive(false);
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
