using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController: MonoBehaviour  {

    public List<CharacterData> playerTeam;
    public List<ItemData> items;

    void Start()
    {
        UIManager.Instance.CreateInventoryPanel();
        InventoryPanel.Instance.items = items;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            InventoryPanel.Instance.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.P))
            InventoryPanel.Instance.gameObject.SetActive(false);
    }

	public void AddCharacter(CharacterData character)
    {
        playerTeam.Add(character);
    }

    



}
