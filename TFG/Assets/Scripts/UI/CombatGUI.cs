using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatGUI : MonoBehaviour {

    public GameObject HealthPanel;
    private List<BaseStatCharacter> PlayerTeam;

    public static CombatGUI instance;

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
  
    public void CreateHealthBars(List<GameObject> playerFighters)
    {
        foreach(GameObject objFighter in playerFighters)
        {
            CharacterFighter fighter = objFighter.GetComponent<CharacterFighter>();
            addHealthPanel(fighter);
        }
    }
   

    private void addHealthPanel(CharacterFighter charac)
    {
        GameObject healthPanelObj = Resources.Load("UI/HealthPanel") as GameObject;
        GameObject panel = GameObject.Instantiate(healthPanelObj, healthPanelObj.transform.position, healthPanelObj.transform.rotation) as GameObject;

        HealthPanel healthPanel = panel.GetComponent<HealthPanel>();
        if (panel != null)
        {
            Transform t = panel.transform;
            t.SetParent(HealthPanel.transform, false);
            //t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            panel.layer = gameObject.layer;

        }
        panel.name = charac.name;

        charac.addHealthBar(healthPanel);
    }
}
