using UnityEngine;
using System.Collections;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    public static PlayerMovement player = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
    }


}
