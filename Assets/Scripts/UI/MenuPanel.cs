using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour {

    public GameObject HealtPanels;


    void Start()
    {
        addHealthPanels();
    }

    public void Save()
    {
        SaveLoadManager.SaveSlot();
    }

 
    public void cambiarIdioma(string key)
    {
        CSVReader.Instance.ChangeLanguage(key);
    }

    public void ShowInventory()
    {
        UIManager.Instance.CreateInventoryPanel();
        UIManager.Instance.RemovePanel(gameObject);
    }

    private void addHealthPanels()
    {
        foreach (CharacterData charac in GameGlobals.GetPlayerTeamController().currentPlayerTeam)
        {
            GameObject healthPanelObj = Resources.Load("UI/CombatGUI/HealthPanel") as GameObject;
            GameObject panel = GameObject.Instantiate(healthPanelObj, healthPanelObj.transform.position, healthPanelObj.transform.rotation) as GameObject;

            ScriptingUtils.addChild(panel, HealtPanels);

            HealthPanel healthPanel = panel.GetComponent<HealthPanel>();
            panel.name = "HealthBar_" + charac.name;
            healthPanel.addCharacter(charac);
        }
    }

    public void BackToMainPanel()
    {
        StartCoroutine(EndScene());
    }

    private IEnumerator EndScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        yield return null;
    }
   
}
