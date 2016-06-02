using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChooseCharacterPanel : MonoBehaviour {

    public GameObject characterPanelsParent;
    public List<CharacterPanel> panels = new List<CharacterPanel>();

    public void CreateCharacterPanels(ItemData item)
    {
        //Controlamos que solo se pulse una vez en el objeto para que no siga creando CharacterPanels
        if (panels.Count == 0)
            ChargePanels(item);
    }

    private void ChargePanels(ItemData item)
    {
        foreach (CharacterData charac in GameGlobals.playerTeamController.playerTeam)
        {
            GameObject panelObj = Resources.Load("UI/Inventory/CharacterPanel") as GameObject;
            GameObject panelInstantiate = GameObject.Instantiate(panelObj, characterPanelsParent.transform.position, Quaternion.identity) as GameObject;

            addChild(panelInstantiate, characterPanelsParent);
            panelInstantiate.name = "ChoosePanel_" + charac.CharacterName;

            CharacterPanel panel = panelInstantiate.GetComponent<CharacterPanel>();
            panel.setCharacter(charac, item);
            panels.Add(panel);
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
