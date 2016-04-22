using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatGUI : MonoBehaviour {

    public GameObject HealthPanel;
    public GameObject ActionPanel;
    public GameObject TurnFighterPanels;

    private static CombatGUI instance;

    public static CombatGUI Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }
  
    public void CreateCharactersPanels(List<CharacterFighter> playerFighters)
    {
        foreach(CharacterFighter fighter in playerFighters)
        {
            addHealthPanel(fighter);
            addActionPanel(fighter);
        }
    }
   
    public void CreateTurnFighterPanels(List<Fighter> fighters)
    {
        foreach(Fighter fighter in fighters)
        {
            addTurnFightPanel(fighter);
        }
    }

    private void addHealthPanel(CharacterFighter charac)
    {
        GameObject healthPanelObj = Resources.Load("UI/HealthPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(healthPanelObj, healthPanelObj.transform.position, healthPanelObj.transform.rotation) as GameObject;

        addChild(panel, HealthPanel);

        HealthPanel healthPanel = panel.GetComponent<HealthPanel>();
        panel.name = "HealthBar_" + charac.name;
        charac.addHealthBar(healthPanel);
    }

    private void addActionPanel(CharacterFighter charac)
    {
        GameObject actionPanelObj = Resources.Load("UI/ActionPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(actionPanelObj, actionPanelObj.transform.position, actionPanelObj.transform.rotation) as GameObject;

        addChild(panel, ActionPanel);
        panel.SetActive(false);
        panel.name = "ActionBar_" + charac.name;
        ActionPanel actionPanel = panel.GetComponent<ActionPanel>();
        charac.addActionPanel(actionPanel);
    }

    private void addTurnFightPanel(Fighter fighter)
    {
        GameObject actionPanelObj = Resources.Load("UI/TurnfighterPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(actionPanelObj, actionPanelObj.transform.position, actionPanelObj.transform.rotation) as GameObject;

        addChild(panel, TurnFighterPanels);
        panel.SetActive(true);
        panel.name = "TurnFighter_" + fighter.name;
        TurnFighterPanel actionPanel = panel.GetComponent<TurnFighterPanel>();
        fighter.addTurnPanel(actionPanel);
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
