using UnityEngine;
using System.Collections;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";
    public static string TagFightStage = "FightStage";

    //Atributos enemigo Animator
    public const string INPUT_X = "input_x";
    public const string INPUT_Y = "input_y";
    public const string ATTACK = "attack";
    public const string HURT = "hurt";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    public static PlayerMovement player = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();
    public static CameraControll camera = Camera.main.GetComponent<CameraControll>();

    public static GameObject Backreference;

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
    }

    public static IEnumerator ChangeCameraToFight()
    {
        yield return ScriptingUtils.DoAFadeIn();       
        camera.GoToBackgroundGiven(GameObject.FindGameObjectWithTag(TagFightStage));       
        yield return ScriptingUtils.DoAFadeOut();      
    }

    public static void saveBackReference(GameObject back)
    {
        Backreference = back;
    }

}
