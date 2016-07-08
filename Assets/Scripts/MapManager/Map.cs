using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

    public GameObject MainMap;
    public GameObject FightStage;
    public SoundMap AudioSource;
    public List<GameObject> ExternalExits;
    public List<GameObject> InternalMaps;

    public SoundMap GetAudioSource()
    {
        return AudioSource;
    }

    public GameObject GetFightStage()
    {
        return FightStage;
    }

    public GameObject GetMainMap()
    {
        return MainMap;
    }

    public GameObject GetExternalExit(string name)
    {
        foreach (GameObject obj in ExternalExits)
            if (obj.name.Equals(name))
                return obj;
        return null;
    }

    public GameObject GetHouse(string name)
    {
        foreach (GameObject obj in InternalMaps)
            if (obj.name.Equals(name))
                return obj;
        return MainMap;
    }

    public TurnBattleHandler GetTurnBattleHandler()
    {
        return FightStage.GetComponent<TurnBattleHandler>();
    }
}
