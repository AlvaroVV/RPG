using UnityEngine;
using System.Collections;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";

    //Atributos enemigo Animator
    public const string INPUT_X = "input_x";
    public const string INPUT_Y = "input_y";
    public const string ATTACK = "attack";
    public const string HURT = "hurt";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    public static PlayerMovement player = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
    }


}
