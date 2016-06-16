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


    public void Estado_Correr_Parado(Vector2 movement,Vector2 direction)
    {
        if (movement != Vector2.zero)
        {
            anim.SetFloat(input_x, movement.x);
            anim.SetFloat(input_y, movement.y);
            anim.SetBool(isRunning, true);
        }
        else if(direction != Vector2.zero)
        {
            anim.SetBool(isRunning, false);
            anim.SetFloat(input_x, direction.x);
            anim.SetFloat(input_y, direction.y);
        }
        else
            anim.SetBool(isRunning, false);
    }

	
}


