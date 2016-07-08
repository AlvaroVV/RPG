using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController: MonoBehaviour  {

    private List<CharacterState> currentCharacterStates;
    public List<CharacterData> currentPlayerTeam;
    public List<ItemData> items;


    public void LoadTeamAndInventory()
    {
        LoadItems();
        LoadCharacterDatas();
    }


	public void AddCharacter(CharacterData character)
    {
       currentPlayerTeam.Add(character);
    }


    public void LoadCharacterDatas()
    {
        currentCharacterStates = GameSlotInfo.currentGameSlot.characterStates;
        foreach (CharacterState state in currentCharacterStates)
        {
            CharacterData character = Resources.Load("Characters/CharactersDatas/" + state.CharacterName) as CharacterData;
            state.LoadCharacter(character);
            LoadCharacterSpecialAttack(character,state.SpecialAttack);
            currentPlayerTeam.Add(character);
           
        }
    }

    private void LoadCharacterSpecialAttack(CharacterData data, string name)
    {
        if(!name.Equals(""))
            data.specialAttack = Resources.Load("Characters/CharactersAttacks/" + name) as BaseAttack;
       
    }

    public List<CharacterState> SaveCharacterDatas()
    {
        List<CharacterState> states = new List<CharacterState>();
        foreach (CharacterData character in currentPlayerTeam)
        {
            CharacterState state = new CharacterState();
            state.SaveCharacter(character);
            states.Add(state);
        }

        return states;
    }

    private void LoadItems()
    {
        List<string> itemPaths = GameSlotInfo.currentGameSlot.itemsNames;
        foreach(string itemPath in itemPaths)
        {
            ItemData item = Resources.Load(itemPath) as ItemData;
            items.Add(item);
        }
    }

    public List<string> SaveItems()
    {
        List<string> itemPaths = new List<string>();
        foreach(ItemData item in items)
        {
            itemPaths.Add(item.GetItemPath());
        }

        return itemPaths;
    }

    public void AddItemData(ItemData data)
    {
        items.Add(data);
    }

    public bool LookForItemInventory(ItemData data)
    {
        return items.Contains(data);
    }


}
