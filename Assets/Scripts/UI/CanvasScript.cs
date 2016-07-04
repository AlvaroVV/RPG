using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    private Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}

    public void ChangeCanvasMode(RenderMode mode)
    {
        canvas.renderMode = mode;
    }
}
