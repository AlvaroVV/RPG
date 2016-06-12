using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

    public int order;
    public string layer;

    private ParticleSystemRenderer rend;

    void OnValidate()
    {
        Set();
    }

    void OnEnabled()
    {
        Debug.Log("EMPIEZA");
        Set();
    }

    void Start()
    {
        Debug.Log("Empieza");
        rend = GetComponent<ParticleSystemRenderer>();
        //GetComponent<ParticleSystem>().Simulate(1, true, false);
    }
    private void Set()
    {
        if (rend == null)
            rend = GetComponent<ParticleSystemRenderer>();
        rend.sortingLayerName = layer;
        rend.sortingOrder = order;
    }

}
