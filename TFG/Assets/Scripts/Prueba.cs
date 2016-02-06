using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Prueba : MonoBehaviour {

	void Awake()
    {

        Dictionary<string,Dictionary<string, string>> data = CSVReader.Instance.Read("Internacionalizacion");
        
    }
}
