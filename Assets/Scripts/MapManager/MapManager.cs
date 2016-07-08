using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public string MapName = "";
    public string DoorName = "";

    public static MapManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static MapManager instance;
    private GameObject actualMap;

    void Start()
    {
        if (!MapName.Equals("") && !DoorName.Equals(""))
        {
            StartCoroutine(UseExternalDoor(MapName, DoorName));
            CSVReader.Instance.Read("Texts/Textos");
        }
    }

    void Awake()
    {
        instance = this;
    }


    public string GetActualMapName()
    {
        return actualMap.name;
    }

    public Map GetActualMap()
    {
        return actualMap.GetComponent<Map>();
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
        GameGlobals.GetPlayerMovement().StateInteracting();
        yield return ScriptingUtils.DoAFadeIn();

        Destroy(actualMap);
        LoadMap(mapName);
        Map mapa = actualMap.GetComponent<Map>();

        GameGlobals.GetPlayer().transform.position = mapa.GetExternalExit(doorName).transform.position;

        yield return ScriptingUtils.DoAFadeOut();
        GameGlobals.GetPlayerMovement().StateIdle();
    }



    public void GoToFightStage()
    {
        Map mapa = actualMap.GetComponent<Map>();
        GameGlobals.GetCameraControll().GoToFightStage(mapa.GetFightStage());
        mapa.GetMainMap().SetActive(false);
    }


    public void GoToMainMap()
    {
        Map mapa = actualMap.GetComponent<Map>();
        GameObject mainMap = mapa.GetMainMap();

        mainMap.SetActive(true);
        GameGlobals.GetCameraControll().GoToBackgroundGiven(mainMap);
        
    }

    public TurnBattleHandler GetTurnBattleHandler()
    {
        Map mapa = actualMap.GetComponent<Map>();
        return mapa.GetTurnBattleHandler();
    }

    public void DestroyActualMap()
    {
        Destroy(actualMap);
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
