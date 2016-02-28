using UnityEngine;
using System.Collections;
using Tiled2Unity;

public class CameraControll : MonoBehaviour
{
    //Mapa Inicio, (temporal)
    public GameObject background;
    private Transform playerTransform;

    private bool canMove = true;

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
        //Buscamos el primer mapa
        playerTransform = GameObject.FindGameObjectWithTag(GameGlobals.TagPlayer).GetComponent<Transform>();

        calcularParametrosCamara();
        calcularTamañoMapa(background);
        Debug.Log(cameraWidth);
        Debug.Log(background.GetComponent<TiledMap>().GetMapHeightInPixelsScaled());
    }


    // Update is called once per frame
    void Update()
    {
        MoverCamara();
    }

    void MoverCamara()
    {
        if (canMove)
        {
            float positionX = playerTransform.position.x;
            float positionY = playerTransform.position.y;

            float min_X = min_x + cameraWidth / 2;
            float max_X = max_x - cameraWidth / 2;

            float min_Y = min_y + cameraHeigth / 2;
            float max_Y = max_y - cameraHeigth / 2;

            float movimientoX = Mathf.Clamp(positionX, min_X, max_X);
            float movimientoY = Mathf.Clamp(positionY, min_Y, max_Y);

            transform.position = new Vector3(movimientoX, movimientoY, transform.position.z);
        }
    }


    public void calcularTamañoMapa(GameObject background)
    {
        if (background.GetComponent<TiledMap>() != null)
        {
            min_x = background.transform.position.x;
            max_x = background.transform.position.x + background.GetComponent<TiledMap>().GetMapWidthInPixelsScaled();

            max_y = background.transform.position.y;
            min_y = background.transform.position.y - background.GetComponent<TiledMap>().GetMapHeightInPixelsScaled();

            checkBackground(background);
        }
        else
            Debug.LogError("El GameObject no tiene componente TiledMap");
    }

    void calcularParametrosCamara()
    {
        camara = Camera.main;
        cameraHeigth = camara.orthographicSize * 2f;
        cameraWidth = cameraHeigth * camara.aspect;
    }

    void checkBackground(GameObject background)
    {
        float backWidth = background.GetComponent<TiledMap>().GetMapWidthInPixelsScaled();
        float backHeigth = background.GetComponent<TiledMap>().GetMapHeightInPixelsScaled();

        if ((backWidth < cameraWidth) && (backWidth < cameraWidth))
        {
            
            camara.transform.position = new Vector3(background.transform.position.x + backWidth/2,
                                                    background.transform.position.y - backHeigth/2,
                                                    camara.transform.position.z);
            canMove = false;
        }
        else canMove = true;
    }


    
}
