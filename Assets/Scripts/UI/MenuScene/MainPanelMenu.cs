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
    public GameObject OptionsMenu;

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
        CSVReader.Instance.Read("Texts/Textos");
    }

    public void ClickNewGame()
    {
        NewGameMenu.SetActive(true);
    }

    public void StartNewGame()
    {
        string name = slotNameText.text;
        if (!name.Equals(""))
        {
            SaveLoadManager.NewGameSlot();
            GameSlotInfo.currentGameSlot.gameSlotName = name;
            SceneManager.LoadScene(1);
        }
    }

    public void ClickOptions()
    {
        PanelMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void ClickStart()
    {
        PanelMenu.SetActive(false);
        GameSlotsMenu.SetActive(true);
    }

    public void ClickContinue()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ClickDelete()
    {
        SaveLoadManager.DeleteGameSlot();
        if(MenuContinue.Instance!=null)
            MenuContinue.Instance.RestartPanel();
        ContinuePanel.SetActive(false);
        PanelMenu.SetActive(true);
    }

    public void ClickSpanish()
    {
        CSVReader.Instance.ChangeLanguage(CSVReader.ESPAÑOL);
        if (MenuContinue.Instance != null)
            MenuContinue.Instance.RestartPanel();
        ButtonBack();
    }

    public void ClickEnglish()
    {
        CSVReader.Instance.ChangeLanguage(CSVReader.ENGLISH);
        if (MenuContinue.Instance != null)
            MenuContinue.Instance.RestartPanel();
        ButtonBack();
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ButtonBack()
    {
        NewGameMenu.SetActive(false);
        GameSlotsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        ContinuePanel.SetActive(false);
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
