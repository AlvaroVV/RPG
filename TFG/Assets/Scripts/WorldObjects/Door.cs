using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject exit;
    public GameObject background;
    	
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals(GameGlobals.TagPlayer))
        {
            GameGlobals.playerMovement.StateInteracting();
            yield return ScriptingUtils.DoAFadeIn();         
            changePosition(other);
            yield return ScriptingUtils.DoAFadeOut();
            GameGlobals.playerMovement.StateIdle();
        }
    }

    void changePosition(Collider2D other)
    {
        CameraControll cam = Camera.main.GetComponent<CameraControll>();
        cam.GoToBackgroundGiven(background);
        other.gameObject.transform.position = exit.transform.position;
    }
}
