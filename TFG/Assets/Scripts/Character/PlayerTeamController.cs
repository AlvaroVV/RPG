using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController: MonoBehaviour  {

    public List<CharacterState> currentCharacterStates;
    public List<CharacterData> currentPlayerTeam;
    public List<ItemData> items;

    private GameObject menuPanel;

    void Start()
    {
        //Cargamos los objetos desde el GameSlot
        LoadItems();
        LoadCharacterDatas();
    }

    void Update()
    {
        OpenCloseMenuPanel();
    }

    private void OpenCloseMenuPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuPanel == null)
            menuPanel = UIManager.Instance.CreateMenuPanel();
        else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel != null)
        {
            string lastPanelName = UIManager.Instance.Pop();
            if (lastPanelName.Equals("UI/MenuPanel"))
                menuPanel = null;
        }
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
            CharacterData character = Resources.Load(state.CharacterPath) as CharacterData;
            state.LoadCharacter(character);
            currentPlayerTeam.Add(character);
            
        }
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
            itemPaths.Add(item.ItemPath);
        }

        return itemPaths;
    }


}
