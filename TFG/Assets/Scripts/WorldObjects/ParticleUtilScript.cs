using UnityEngine;
using System.Collections;

public class ParticleUtilScript : MonoBehaviour {

    [Range(0, 8)]
    public float maxIntensity = 3;
    public float increment = 0.05f;

    private Light lightC;
    private ParticleSystem particle;


	// Use this for initialization
	void Start () {
        lightC = GetComponentInChildren<Light>();
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(FadeInLight());
	}

    private IEnumerator FadeInLight()
    {
        while(lightC.intensity < maxIntensity)
        {
            lightC.intensity += increment;
            yield return null;
            Debug.Log(particle.isPlaying);
        }
        yield return null;

    }
	
}
