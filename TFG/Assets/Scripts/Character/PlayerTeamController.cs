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
        items = GameSlotInfo.currentGameSlot.itemsNames;
        LoadCharacterDatas();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            UIManager.Instance.CreateInventoryPanel();
        if (Input.GetKeyDown(KeyCode.Escape))
            UIManager.Instance.Pop();
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
            currentPlayerTeam.Add(state.OriginalData);
            state.LoadCharacter();
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



}
