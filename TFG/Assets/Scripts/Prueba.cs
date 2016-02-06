using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Prueba : MonoBehaviour {

	

    void OnGUI()
    {
        GUILayout.Label(CSVReader.Instance.GetWord("Lenguaje"));
        if (GUILayout.Button("Español"))
        {
            CSVReader.Instance.ChangeLanguage(CSVReader.ESPAÑOL);
            Debug.Log("Elegido idioma Español");
        }
        if (GUILayout.Button("English"))
        {
            CSVReader.Instance.ChangeLanguage(CSVReader.ENGLISH);
            Debug.Log("English language chosen");
        }
        if (GUILayout.Button(CSVReader.Instance.GetWord("Botón_Hola")))
            Debug.Log(CSVReader.Instance.GetWord("Saludo1"));
        if (GUILayout.Button(CSVReader.Instance.GetWord("Botón_Adiós")))
            Debug.Log(CSVReader.Instance.GetWord("Hola"));
        if (GUILayout.Button(CSVReader.Instance.GetWord("Botón_Saludo1")))
            Debug.Log(CSVReader.Instance.GetWord("Adiós"));
    }
}
