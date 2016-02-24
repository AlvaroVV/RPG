using UnityEngine;
using System.Collections;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";

}
