using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatGUI : MonoBehaviour {

    public GameObject HealthPanel;

    private List<BaseStatCharacter> PlayerTeam;

	// Use this for initialization
	void Start () {
        PlayerTeam = GameGlobals.player.playerTeam;
        ChargeHealthPanels();
	}

    private void ChargeHealthPanels()
    {
        foreach (BaseStatCharacter charac in PlayerTeam)
        {
            addHealthPanel(charac);
        }
    }

    private void addHealthPanel(BaseStatCharacter charac)
    {
        GameObject healthPanel = Resources.Load("UI/HealthPanel") as GameObject;
        healthPanel.GetComponent<HealthPanel>().addCharacter(charac);

        GameObject panel = GameObject.Instantiate(healthPanel, healthPanel.transform.position, healthPanel.transform.rotation) as GameObject;
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

    }
}
