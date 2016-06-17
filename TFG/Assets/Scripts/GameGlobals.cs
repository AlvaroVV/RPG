using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerEnemy = LayerMask.NameToLayer("Enemy");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";
    public static string TagFightStage = "FightStage";
    public static string TagTurnBattle = "TurnBattleHandler";
    public static string TagCanvas = "Canvas";

    //Atributos enemigo Animator
    public const string INPUT_X = "input_x";
    public const string INPUT_Y = "input_y";
    public const string ATTACK = "attack";
    public const string HURT = "hurt";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    public static GameObject player = GameObject.FindGameObjectWithTag(TagPlayer);
    public static PlayerMovement playerMovement = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();
    public static PlayerTeamController playerTeamController = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerTeamController>();
    public static PlayerAnimHandler playerAnimHandler = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerAnimHandler>();
    public static CameraControll camera = Camera.main.GetComponent<CameraControll>();

    //Referencia al background cuando lo inactivas al empezar una batalla
    public static GameObject BackReference = GameObject.FindGameObjectWithTag(TagBackground);

    //Referencia al objeto TurnBattle para empezar la batalla
    public static GameObject TurnBattle =  GameObject.FindGameObjectWithTag(TagTurnBattle);

    //Referencia al Canvas
    public static GameObject Canvas = GameObject.FindGameObjectWithTag(TagCanvas);

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
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
        playerMovement.StateInteracting();

        TurnBattleHandler handler = TurnBattle.GetComponent<TurnBattleHandler>();
        handler.StartCoroutine(handler.StartFight(enemy));
        ChangeCanvasRenderMode(RenderMode.ScreenSpaceCamera);              
    }

    public static IEnumerator FinishFight()
    {       
        yield return ScriptingUtils.DoAFadeIn();
        BackReference.gameObject.SetActive(true);
        camera.GoToMainBackground();
        UIManager.Instance.Pop();

        yield return ScriptingUtils.DoAFadeOut();
        FighterActionManager.Instance.CleanCharactersList();
        ChangeCanvasRenderMode(RenderMode.ScreenSpaceOverlay);

        playerMovement.StateIdle();
    }

    public static void saveBackReference(GameObject back)
    {
        BackReference = back;
    }

    public static void saveTurnBattleReference(GameObject turnBattle)
    {
        TurnBattle = turnBattle;
    }

    public static void ChangeCanvasRenderMode(RenderMode mode)
    {
        Canvas.GetComponent<CanvasScript>().ChangeCanvasMode(mode);
    }

   

}
