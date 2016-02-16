using UnityEngine;
using System.Collections;
using Tiled2Unity;

public class CameraControll : MonoBehaviour {

    private Transform playerTransform;
    private GameObject fondo { get; set; }

    //Atributos cámara
    private Camera camara;
    private float cameraHeigth;
    private float cameraWidth;

    //Atributos mapa
    private float min_x; //X del mapa
    private float max_x; //X + ancho del mapa
    private float min_y; //Y del mapa
    private float max_y; //Y + alto del mapa

  
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Transform>();
        fondo = GameObject.FindGameObjectWithTag(Tags.Background);

        calcularParametrosCamara();
        calcularTamañoMapa();
    }

		
	// Update is called once per frame
	void Update () {

        MoverCamara();
	}

    void MoverCamara()
    {
         
        float positionX = playerTransform.position.x;
        float positionY = playerTransform.position.y;
        
        float min_X = min_x + cameraWidth/ 2;
        float max_X = max_x - cameraWidth/ 2;

        float min_Y = min_y + cameraHeigth/ 2;
        float max_Y = max_y - cameraHeigth/ 2;

        Debug.Log("Max_X: " + max_X + "Min_X: "+min_X);
        Debug.Log("Max_Y: " + max_Y + "Min_Y: " + min_Y);

        float movimientoX = Mathf.Clamp(positionX,min_X,max_X);
        float movimientoY = Mathf.Clamp(positionY, min_Y, max_Y);

        transform.position = new Vector3(movimientoX,movimientoY,transform.position.z);
    }


    void calcularTamañoMapa()
    {
        min_x = fondo.transform.position.x;
        max_x = fondo.transform.position.x + fondo.GetComponent<TiledMap>().GetMapWidthInPixelsScaled();
        
        max_y = fondo.transform.position.y;
        min_y = fondo.transform.position.y - fondo.GetComponent<TiledMap>().GetMapHeightInPixelsScaled();
    }

    void calcularParametrosCamara()
    {
        camara = Camera.main;
        cameraHeigth = camara.orthographicSize * 2f;
        cameraWidth = cameraHeigth * camara.aspect;
    }
}
