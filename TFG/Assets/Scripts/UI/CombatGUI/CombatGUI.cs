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
            if (instance == null)
                UIManager.Instance.CreateCombatGUI("UI/CombatGUI/CombatGUI");
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
        GameObject healthPanelObj = Resources.Load("UI/CombatGUI/HealthPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(healthPanelObj, healthPanelObj.transform.position, healthPanelObj.transform.rotation) as GameObject;

        ScriptingUtils.addChild(panel, HealthPanel);

        HealthPanel healthPanel = panel.GetComponent<HealthPanel>();
        panel.name = "HealthBar_" + charac.name;
        charac.addHealthBar(healthPanel);
    }

    private void addActionPanel(CharacterFighter charac)
    {
        GameObject actionPanelObj = Resources.Load("UI/CombatGUI/ActionPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(actionPanelObj, actionPanelObj.transform.position, actionPanelObj.transform.rotation) as GameObject;

        ScriptingUtils.addChild(panel, ActionPanel);
        panel.SetActive(false);
        panel.name = "ActionBar_" + charac.name;
        ActionPanel actionPanel = panel.GetComponent<ActionPanel>();
        charac.addActionPanel(actionPanel);
    }

    private void addTurnFightPanel(Fighter fighter)
    {
        GameObject actionPanelObj = Resources.Load("UI/CombatGUI/TurnfighterPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(actionPanelObj, actionPanelObj.transform.position, actionPanelObj.transform.rotation) as GameObject;

        ScriptingUtils.addChild(panel, TurnFighterPanels);
        panel.SetActive(true);
        panel.name = "TurnFighter_" + fighter.name;
        TurnFighterPanel actionPanel = panel.GetComponent<TurnFighterPanel>();
        fighter.addTurnPanel(actionPanel);
    }

}
