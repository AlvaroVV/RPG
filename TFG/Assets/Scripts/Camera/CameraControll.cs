using UnityEngine;
using System.Collections;
using Tiled2Unity;

public class CameraControll : MonoBehaviour
{
    public GameObject blackPanel;
    public GameObject target;

    private Transform playerTransform;

    private bool canMove = true;

    //Atributos cámara
    private Camera camara;
    private float cameraHeigth;
    private float cameraWidth;
    private float cam_minX;
    private float cam_maxX;
    private float cam_minY;
    private float cam_maxY;

    //Atributos mapa
    private float min_x; //X del mapa
    private float max_x; //X + ancho del mapa
    private float min_y; //Y del mapa
    private float max_y; //Y + alto del mapa


    void Awake()
    {
        playerTransform = target.transform;
        calcularParametrosCamara();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        MoverCamara();
    }

    /// <summary>
    /// Método que mueve la cámara siguiendo al personaje, además tendrá en cuenta los límites del mapa.
    /// </summary>
    void MoverCamara()
    {
        if (canMove)
        {
            float movimientoX = Mathf.Clamp(playerTransform.position.x, cam_minX, cam_maxX);
            float movimientoY = Mathf.Clamp(playerTransform.position.y, cam_minY, cam_maxY);

            transform.position = new Vector3(movimientoX, movimientoY, transform.position.z);
        }
    }

   

    /// <summary>
    /// Método que calcula el tamaño de un mapa dado
    /// </summary>
    /// <param name="background">mapa que se quiere calcular</param>
    public void GoToBackgroundGiven(GameObject background)
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

    /// <summary>
    /// Método que calcula los parámetros del escenario del combate por turno y sitúa la camara en el medio.
    /// </summary>
    /// <param name="fightStage"></param>
    public void GoToFightStage(GameObject fightStage)
    {
        //En la pelea la camara no se moverá
        canMove = false;
        if (fightStage.GetComponent<TiledMap>() != null)
        {
            float backWidth = fightStage.GetComponent<TiledMap>().GetMapWidthInPixelsScaled();
            float backHeigth = fightStage.GetComponent<TiledMap>().GetMapHeightInPixelsScaled();

            camara.transform.position = new Vector3(fightStage.transform.position.x + backWidth / 2,
                                                     fightStage.transform.position.y - backHeigth / 2,
                                                     camara.transform.position.z);
        }
        else
            Debug.LogError("El GameObject no tiene componente TiledMap");
    }

    /// <summary>
    /// Método que crea un Panel Negro y sitúa la cámara en el
    /// Se utiliza para cinemáticas que no ocurren en un mapa.
    /// </summary>
    /// <returns></returns>
    public GameObject GoToBlackPanel()
    {
        Debug.Log("Camara");
        canMove = false;
        GameObject blacPanel = Instantiate(blackPanel);

        transform.position = new Vector3(blacPanel.transform.position.x,
                                         blacPanel.transform.position.y,
                                         transform.position.z);
        return blacPanel;
    }

    /// <summary>
    /// Método que calcula el tamaño de la cámara teniendo en cuenta la resolución de la pantalla.
    /// </summary>
    void calcularParametrosCamara()
    {
        camara = Camera.main;
        cameraHeigth = camara.orthographicSize * 2f;
        cameraWidth = cameraHeigth * camara.aspect;
    }

    /// <summary>
    /// Método que comprueba que el mapa es lo suficientemente grande como para que se mueva la camara.
    /// </summary>
    /// <param name="background"></param>
    void checkBackground(GameObject background)
    {
        float backWidth = background.GetComponent<TiledMap>().GetMapWidthInPixelsScaled();
        float backHeigth = background.GetComponent<TiledMap>().GetMapHeightInPixelsScaled();

        cam_minX = min_x + cameraWidth / 2;
        cam_maxX = max_x - cameraWidth / 2;

        cam_minY = min_y + cameraHeigth / 2;
        cam_maxY = max_y - cameraHeigth / 2;

        if ((backWidth < cameraWidth) && (backHeigth < cameraHeigth))
        {
            
            camara.transform.position = new Vector3(background.transform.position.x + backWidth/2,
                                                    background.transform.position.y - backHeigth/2,
                                                    camara.transform.position.z);
            canMove = false;
        }
        else canMove = true;
    }


    
}
