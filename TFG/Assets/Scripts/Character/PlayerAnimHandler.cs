using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimHandler {


    public static string input_x = "input_x";
    public static string input_y = "input_y";
    public static string isRunning = "isRunning";
    public static Animator Animator { get; set; }

    public static void Estado_Correr_Parado(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            Animator.SetFloat(PlayerAnimHandler.input_x, movement.x);
            Animator.SetFloat(PlayerAnimHandler.input_y, movement.y);
            Animator.SetBool(PlayerAnimHandler.isRunning, true);
        }
        else
        {
            Animator.SetBool(PlayerAnimHandler.isRunning, false);
        }
    }

	
}


