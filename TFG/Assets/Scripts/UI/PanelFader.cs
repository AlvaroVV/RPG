using UnityEngine;
using System.Collections;

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
        anim.SetTrigger(FADE_OUT);
        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger(FADE_IN);
        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
	

}
