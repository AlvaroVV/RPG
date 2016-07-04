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

            ScriptingUtils.addChild(panelInstantiate, characterPanelsParent);
            panelInstantiate.name = "ChoosePanel_" + charac.CharacterName;

            CharacterPanel panel = panelInstantiate.GetComponent<CharacterPanel>();
            panel.SetProperties(charac, itemSlot);
            panels.Add(panel);
        }
    }

   

    private void ShowItem(ItemSlot item)
    {
       itemImage.sprite = item.GetItem().Image;
       itemUnits.text = item.getUnits().ToString();
    }

    public void UpdateUnits(ItemSlot item)
    {
        itemUnits.text = item.getUnits().ToString();
    }
   
}
