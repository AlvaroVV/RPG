using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour {

    private Animator anim;
    private const string FADE_IN = "FadeIn";
    private const string FADE_OUT = "FadeOut";

    private bool isFading = false;

	// Use this for initialization
	void Awake() {
        anim = GetComponent<Animator>();	
	}


    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetBool(FADE_OUT,true);
        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetBool(FADE_IN,true);
        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
	

}
