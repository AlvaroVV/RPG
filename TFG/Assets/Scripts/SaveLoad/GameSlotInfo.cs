using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class GameSlotInfo
{
    public static GameSlotInfo currentGameSlot;

    public string gameSlotName = "";

    public float playerPositionX = -16;
    public float playerPositionY = 11;
    //public List<CharacterData> characters;

    //Lista de items
    public List<ItemData> itemsNames = new List<ItemData>();

    //Lista de states de los personajes
    public List<CharacterState> characterStates = new List<CharacterState>();


}
