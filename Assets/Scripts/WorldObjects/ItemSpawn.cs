using UnityEngine;
using System.Collections;
using System;

public class ItemSpawn : MonoBehaviour, Interactable {

    public ItemData Item;

    private string Information;


    // Use this for initialization
    void Start () {
        Information = CSVReader.Instance.GetWord("ItemSpawn");
        Information += " " + "<color=#0473f0>" + Item.Id  +"</color>";
	}
	

    public IEnumerator Interact()
    {

        yield return ScriptingUtils.showInformation(Information);
        GameGlobals.GetPlayerTeamController().AddItemData(Item);
        Destroy(gameObject);
    }
}
