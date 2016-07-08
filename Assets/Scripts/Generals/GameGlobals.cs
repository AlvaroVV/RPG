using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class GameGlobals
{

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerSelectable = LayerMask.NameToLayer("Selectable");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagCanvas = "Canvas";

    //Atributos enemigo Animator
    public const string INPUT_X = "input_x";
    public const string INPUT_Y = "input_y";
    public const string ATTACK = "attack";
    public const string HURT = "hurt";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    private static GameObject player;
    private static PlayerMovement playerMovement;
    private static PlayerTeamController playerTeamController;
    private static PlayerAnimManager playerAnimHandler;
    private static PlayerLoader playerLoader;
    private static CameraControll camera;


    //Referencia al Canvas
    private static GameObject Canvas = GameObject.FindGameObjectWithTag(TagCanvas);

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
        Menu,
        Fighting,
    }

    public enum CharacterType
    {
        EARTH,
        FIRE,
        WIND,
        WATER,
    }

    public enum AttackType
    {
        Attack,
        Magic,
    }

    public static void StartFight(StateMachineEnemy enemy)
    {
        GetPlayerMovement().StateFighting();

        TurnBattleHandler handler = MapManager.Instance.GetTurnBattleHandler();
        handler.StartCoroutine(handler.StartFight(enemy));
        ChangeCanvasRenderMode(RenderMode.ScreenSpaceCamera);
    }

    public static IEnumerator FinishFight()
    {
        yield return ScriptingUtils.DoAFadeIn();

        MapManager.Instance.GoToMainMap();
        UIManager.Instance.Pop();

        yield return ScriptingUtils.DoAFadeOut();
        FighterActionManager.Instance.CleanCharactersList();
        ChangeCanvasRenderMode(RenderMode.ScreenSpaceOverlay);

        GetPlayerMovement().StateIdle();
    }


    public static void ChangeCanvasRenderMode(RenderMode mode)
    {
        GetCanvas().GetComponent<CanvasScript>().ChangeCanvasMode(mode);
    }

    public static GameObject GetPlayer()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag(TagPlayer);
        return player;
    }

    public static PlayerMovement GetPlayerMovement()
    {
        if(playerMovement == null)
            playerMovement = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();
        return playerMovement;
    }

    public static PlayerTeamController GetPlayerTeamController()
    {
        if(playerTeamController == null)
            playerTeamController = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerTeamController>();
        return playerTeamController;
    }

    public static PlayerAnimManager GetPlayerAnimManager()
    {
        if(playerAnimHandler == null)
            playerAnimHandler = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerAnimManager>();
        return playerAnimHandler;
    }

    public static PlayerLoader GetPlayerLoader()
    {
        if(playerLoader == null)
            playerLoader = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerLoader>();
        return playerLoader;

    }

    public static CameraControll GetCameraControll()
    {
        if(camera==null)
            camera = Camera.main.GetComponent<CameraControll>();
        return camera;
    }

    public static GameObject GetCanvas()
    {
        if(Canvas == null)
            Canvas = GameObject.FindGameObjectWithTag(TagCanvas);
        return Canvas;
    } 
    
}


