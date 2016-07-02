using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {


    public static MapManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static MapManager instance;
    private GameObject actualMap;

    void Awake()
    {
        instance = this;
    }


    public string GetActualMapName()
    {
        return actualMap.name;
    }
	
    public void LoadMap(string mapName)
    {       
        GameObject res_map = Resources.Load("Mapas/" + mapName) as GameObject;
        actualMap = Instantiate(res_map);
        actualMap.name = mapName;
        addChildMap(actualMap);
        GoToMainMap();
    }

    public void UseExternalDoorCoroutine(string mapName, string doorName)
    {
        StartCoroutine(UseExternalDoor(mapName, doorName));
    }

    private IEnumerator UseExternalDoor(string mapName, string doorName)
    {
        GameGlobals.playerMovement.StateInteracting();
        yield return ScriptingUtils.DoAFadeIn();

        Destroy(actualMap);
        LoadMap(mapName);
        Map mapa = actualMap.GetComponent<Map>();

        GameGlobals.player.transform.position = mapa.GetExternalExit(doorName).transform.position;

        yield return ScriptingUtils.DoAFadeOut();
        GameGlobals.playerMovement.StateIdle();
    }

    public IEnumerator UseInternalDoor(string mapName, GameObject exitPoint)
    {
        Map mapa = actualMap.GetComponent<Map>();
        GameGlobals.playerMovement.StateInteracting();
        yield return ScriptingUtils.DoAFadeIn();

        GameGlobals.camera.GoToBackgroundGiven(mapa.GetHouse(mapName));
        GameGlobals.player.transform.position = exitPoint.transform.position;

        yield return ScriptingUtils.DoAFadeOut();
        GameGlobals.playerMovement.StateIdle();

    }


    public void GoToFightStage()
    {
        Map mapa = actualMap.GetComponent<Map>();
        GameGlobals.camera.GoToFightStage(mapa.GetFightStage());
        mapa.GetMainMap().SetActive(false);
    }


    public void GoToMainMap()
    {
        Map mapa = actualMap.GetComponent<Map>();
        GameObject mainMap = mapa.GetMainMap();

        mainMap.SetActive(true);
        GameGlobals.camera.GoToBackgroundGiven(mainMap);
        
    }

    public TurnBattleHandler GetTurnBattleHandler()
    {
        Map mapa = actualMap.GetComponent<Map>();
        return mapa.GetTurnBattleHandler();
    }

    private void addChildMap(GameObject child)
    {
        if (child != null)
        {
            Transform t = child.transform;
            t.SetParent(gameObject.transform, false);
            t.position = Vector3.zero;
            t.localRotation = Quaternion.identity;
            child.layer = gameObject.layer;
        }
    }
}
