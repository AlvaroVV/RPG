﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameGlobals  {

    //Layer
    public static LayerMask LayerPlayer = LayerMask.NameToLayer("Player");
    public static LayerMask LayerInteractable = LayerMask.NameToLayer("Interactable");
    //Tags
    public static string TagPlayer = "Player";
    public static string TagBackground = "Background";
    public static string TagFightStage = "FightStage";
    public static string TagTurnBattle = "TurnBattleHandler";

    //Atributos enemigo Animator
    public const string INPUT_X = "input_x";
    public const string INPUT_Y = "input_y";
    public const string ATTACK = "attack";
    public const string HURT = "hurt";

    //Referencia al Player para cambiar "estado" desde fuera y no tener un Switch enorme con diferentes estados.
    public static PlayerMovement player = GameObject.FindGameObjectWithTag(TagPlayer).GetComponent<PlayerMovement>();
    public static CameraControll camera = Camera.main.GetComponent<CameraControll>();

    //Referencia al background cuando lo inactivas al empezar una batalla
    public static GameObject BackReference = GameObject.FindGameObjectWithTag(TagBackground);

    //Referencia al objeto TurnBattle para empezar la batalla
    public static GameObject TurnBattle =  GameObject.FindGameObjectWithTag(TagTurnBattle);

    public enum PlayerState
    {
        Idle,
        Running,
        Interacting,
    }

    public static IEnumerator StartFight(StateMachineEnemy enemy)
    {

        yield return ScriptingUtils.DoAFadeIn();       
        camera.GoToBackgroundGiven(GameObject.FindGameObjectWithTag(TagFightStage));          
        yield return ScriptingUtils.DoAFadeOut();

        TurnBattle.GetComponent<TurnBattleHandler>().StartFight(enemy);
        
        BackReference.gameObject.SetActive(false);
        Debug.Log(BackReference);
        Debug.Log(TurnBattle);
        
    }

    public static void saveBackReference(GameObject back)
    {
        BackReference = back;
    }

    public static void saveTurnBattleReference(GameObject turnBattle)
    {
        TurnBattle = turnBattle;
    }

}
