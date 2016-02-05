using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

    private Transform playerTransform;
    private SpriteRenderer fondo { get; set; }
  
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Transform>();
        fondo = GameObject.FindGameObjectWithTag(Tags.Background).GetComponent<SpriteRenderer>();         
    }

		
	// Update is called once per frame
	void Update () {

        MoverCamara();
	}

    void MoverCamara()
    {
        Bounds fondoBounds = fondo.bounds;
        Camera cam = Camera.main;
        float cameraHeigth = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeigth * cam.aspect;

        float positionX = playerTransform.position.x;
        float positionY = playerTransform.position.y;
        
        float min_X = fondoBounds.min.x + cameraWidth/ 2;
        float max_X = fondoBounds.max.x - cameraWidth/ 2;

        float min_y = fondoBounds.min.y + cameraHeigth/ 2;
        float max_y = fondoBounds.max.y - cameraHeigth/ 2;

        float movimientoX = Mathf.Clamp(positionX,min_X,max_X);
        float movimientoY = Mathf.Clamp(positionY, min_y, max_y);

        transform.position = new Vector3(movimientoX,movimientoY,transform.position.z);
    }
}
