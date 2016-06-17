using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController: MonoBehaviour  {

    public List<CharacterState> currentCharacterStates;
    public List<CharacterData> currentPlayerTeam;
    public List<ItemData> items;


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
        if (Input.GetKeyDown(KeyCode.Escape) && UIManager.Instance.isEmpty())
        {
            GameGlobals.playerMovement.StateInteracting();
            Time.timeScale = 0;
            UIManager.Instance.CreateMenuPanel();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.Pop();
            if (UIManager.Instance.isEmpty())
            {
                Time.timeScale = 1;
                GameGlobals.playerMovement.StateIdle();
            }
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

    public void AddItemData(ItemData data)
    {
        items.Add(data);
    }

    public bool LookForItemInventory(ItemData data)
    {
        return items.Contains(data);
    }


}
