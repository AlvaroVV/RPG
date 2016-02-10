using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILocalize : MonoBehaviour {

    public string key;
    private Text textObject;

	// Use this for initialization
	void OnEnable()
    {
        textObject = GetComponentInChildren<Text>();
        textObject.text = CSVReader.Instance.GetWord(key);
    }
}
