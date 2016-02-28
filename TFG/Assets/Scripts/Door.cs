using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject exit;
    public GameObject background;
    

	
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals(GameGlobals.TagPlayer))
        {
            GameGlobals.player.currentState = GameGlobals.PlayerState.Interacting;
            GameGlobals.player.StopMovement();
            yield return ScriptingUtils.DoAFadeIn();         
            changePosition(other);
            yield return ScriptingUtils.DoAFadeOut();
            GameGlobals.player.currentState = GameGlobals.PlayerState.Idle;
        }
    }

    void changePosition(Collider2D other)
    {
        CameraControll cam = Camera.main.GetComponent<CameraControll>();
        cam.calcularTamañoMapa(background);
        other.gameObject.transform.position = exit.transform.position;
    }
}
