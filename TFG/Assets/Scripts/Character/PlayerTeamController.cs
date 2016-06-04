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
        playerTeam[0].currentHP = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            InventoryPanel.Instance.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.P))
            InventoryPanel.Instance.gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Escape))
            UIManager.Instance.Pop();
    }

	public void AddCharacter(CharacterData character)
    {
        playerTeam.Add(character);
    }

    



}
