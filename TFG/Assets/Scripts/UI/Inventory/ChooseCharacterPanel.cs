using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChooseCharacterPanel : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemUnits;
    public GameObject characterPanelsParent;

    private List<CharacterPanel> panels = new List<CharacterPanel>();

    private static ChooseCharacterPanel instance;
    public static ChooseCharacterPanel Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    public void CreateCharacterPanels(ItemSlot itemSlot)
    {
        ShowItem(itemSlot);
        //Controlamos que solo se pulse una vez en el objeto para que no siga creando CharacterPanels
        if (panels.Count == 0)
            ChargePanels(itemSlot);
    }

    private void ChargePanels(ItemSlot itemSlot)
    {
        foreach (CharacterData charac in GameGlobals.playerTeamController.currentPlayerTeam)
        {
            GameObject panelObj = Resources.Load("UI/Inventory/CharacterPanel") as GameObject;
            GameObject panelInstantiate = GameObject.Instantiate(panelObj, characterPanelsParent.transform.position, Quaternion.identity) as GameObject;

            addChild(panelInstantiate, characterPanelsParent);
            panelInstantiate.name = "ChoosePanel_" + charac.CharacterName;

            CharacterPanel panel = panelInstantiate.GetComponent<CharacterPanel>();
            panel.setCharacter(charac, ref itemSlot);
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

    private void ShowItem(ItemSlot item)
    {
       itemImage.sprite = item.getItem().Image;
       itemUnits.text = item.getUnits().ToString();
    }

    public void UpdateUnits(ItemSlot item)
    {
        itemUnits.text = item.getUnits().ToString();
    }
   
}
