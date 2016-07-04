using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;

[System.Serializable]
public class GameSlots
{
    public GameSlotInfo[] gameSlotsInfo = new GameSlotInfo[5]
    {
        new GameSlotInfo(),
        new GameSlotInfo(),
        new GameSlotInfo(),
        new GameSlotInfo(),
        new GameSlotInfo()
    };
} 


public static class SaveLoadManager {

    public static GameSlots gamesSlots = new GameSlots();

    public static void Save()
    {
        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.json");
        StreamWriter writer = new StreamWriter(file);
       
        string json = JsonUtility.ToJson(gamesSlots,true);
        writer.Write(json);
           
        writer.Close();
        file.Close();

    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.json"))
        {
            Debug.Log(Application.persistentDataPath);
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.json",FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string json = reader.ReadToEnd();
            gamesSlots = JsonUtility.FromJson<GameSlots>(json);
            reader.Close();
            file.Close();

            
        }
    }

    public static void SaveSlot()
    {
        GameGlobals.playerLoader.SaveGameSlotInfo();
        Save();

    }

    

    public static void NewGameSlot()
    {
        //Guardamos la referencia al currentSlot para dirigirnos a él desde las demás clases del juego
        int slot = LookForGameSlotInfo();
        GameSlotInfo.currentGameSlot = NewGameSlotInfo();
        
        gamesSlots.gameSlotsInfo[slot] = GameSlotInfo.currentGameSlot;
    }

    private static GameSlotInfo NewGameSlotInfo()
    {
        GameSlotInfo gameSlotInfo = new GameSlotInfo();
        TextAsset json = Resources.Load("NewGame") as TextAsset;
        Debug.Log(json.text);
        gameSlotInfo = JsonUtility.FromJson<GameSlotInfo>(json.text);
        return gameSlotInfo;
    }

    public static void DeleteGameSlot()
    {
        NewGameSlot();
        Save();
        Load();
    }

    private static int LookForGameSlotInfo()
    {
        for(int i = 0; i<gamesSlots.gameSlotsInfo.Length; i++)
        {
            if (gamesSlots.gameSlotsInfo[i] == GameSlotInfo.currentGameSlot)
                return i;
        }

        return -1;
    }

}
