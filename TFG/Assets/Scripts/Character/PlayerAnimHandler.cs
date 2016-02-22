using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimHandler: MonoBehaviour {


    private string input_x = "input_x";
    private string input_y = "input_y";
    private string isRunning = "isRunning";
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Estado_Correr_Parado(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            anim.SetFloat(input_x, movement.x);
            anim.SetFloat(input_y, movement.y);
            anim.SetBool(isRunning, true);
        }
        else
        {
            anim.SetBool(isRunning, false);
        }
    }

	
}


