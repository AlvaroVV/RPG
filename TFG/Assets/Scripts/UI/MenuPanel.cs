using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class MenuPanel : MonoBehaviour {

    public GameObject HealtPanels;

    private CSVReader displayManager;


    void Awake()
    {
        displayManager = CSVReader.Instance;
    }

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
        foreach (CharacterData charac in GameGlobals.playerTeamController.currentPlayerTeam)
        {
            GameObject healthPanelObj = Resources.Load("UI/CombatGUI/HealthPanel") as GameObject;
            GameObject panel = GameObject.Instantiate(healthPanelObj, healthPanelObj.transform.position, healthPanelObj.transform.rotation) as GameObject;

            addChild(panel, HealtPanels);

            HealthPanel healthPanel = panel.GetComponent<HealthPanel>();
            panel.name = "HealthBar_" + charac.name;
            healthPanel.addCharacter(charac);
        }
    }

    private void addChild(GameObject child, GameObject parent)
    {
        if (child != null)
        {
            Transform t = child.transform;
            t.SetParent(parent.transform, false);
            //t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            child.layer = parent.layer;
        }
    }
}
