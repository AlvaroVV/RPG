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
        StartCoroutine(FirstAnimation());
	}

    public IEnumerator FirstAnimation()
    {
        cameraAnim.Play("CameraMenu");
        StartCoroutine(EndAnimation());

        yield return WaitForAnimation(cameraAnim);
        audioSource.Play();
        StartCoroutine(MainPanelMenu.Instance.StartMenu());
        Instantiate(shine_1);

        yield return new WaitForSeconds(1.5f);
        Instantiate(shine_2);
        
    }

    private IEnumerator EndAnimation()
    {      
        while (!Input.GetKeyDown(KeyCode.Space) && cameraAnim.isPlaying)
            yield return null;      

        cameraAnim["CameraMenu"].time = cameraAnim.clip.length;
    }

    public IEnumerator WaitForAnimation(Animation anim)
    {
        while (anim.isPlaying)
            yield return null;
        yield return null;
    }


}
