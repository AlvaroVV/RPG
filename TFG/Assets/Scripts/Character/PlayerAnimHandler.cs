using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimHandler: MonoBehaviour {


    private string input_x = "input_x";
    private string input_y = "input_y";
    private string isRunning = "isRunning";
    private string sleeping = "sleeping";
    private string wakingUp = "wakingUp";
    private Animator anim;

    private bool finishAnimation;
    
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

    public IEnumerator Estado_durmiendo()
    {
        anim.SetBool(sleeping, true);
        finishAnimation = false;
        while (!finishAnimation)
            yield return null;
        yield return null;
    }

    public IEnumerator Estado_wakingUp()
    {
        anim.SetBool(wakingUp, true);
        finishAnimation = false;
        while (!finishAnimation)
            yield return null;
        yield return null;

        anim.SetBool(sleeping, false);
        anim.SetBool(wakingUp, false);
    }

    public void FinishAnimation()
    {
        finishAnimation = true;
    }
	
}


