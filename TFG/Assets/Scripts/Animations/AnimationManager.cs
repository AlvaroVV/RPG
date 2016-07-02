using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

    public GameObject shine_1;
    public GameObject shine_2;

    private Animation cameraAnim;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        cameraAnim = Camera.main.GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MP_CameraMove());
	}

    /// <summary>
    /// Código que ejecuta la animación del en el Menú Principal.
    /// Si el jugador pulsa la tecla "Espacio" en medio de la animacion, esta finaliza.
    /// </summary>
    /// <returns></returns>
    public IEnumerator MP_CameraMove()
    {
        cameraAnim.Play("CameraMenu");
        StartCoroutine(EndCameraAnimation());

        yield return WaitForAnimation(cameraAnim);
        audioSource.Play();
        StartCoroutine(MainPanelMenu.Instance.StartMenu());
        Instantiate(shine_1);

        yield return new WaitForSeconds(1.5f);
        Instantiate(shine_2);
        
    }

    /// <summary>
    /// Corrutina que comprueba si el usuario pulsa la tecla "espacio", entonces acaba la animación.
    /// </summary>
    /// <returns></returns>
    private IEnumerator EndCameraAnimation()
    {      
        while (!Input.GetKeyDown(KeyCode.Space) && cameraAnim.isPlaying)
            yield return null;      

        cameraAnim["CameraMenu"].time = cameraAnim.clip.length;
    }

    /// <summary>
    /// Corrutina que espera a que una animación acabe.
    /// </summary>
    /// <param name="anim">Componente Animation</param>
    /// <returns></returns>
    public IEnumerator WaitForAnimation(Animation anim)
    {
        while (anim.isPlaying)
            yield return null;
        yield return null;
    }


}
