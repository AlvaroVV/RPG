using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILabelLocalize : MonoBehaviour {

    public string key;
    private Text textObject;

    // Use this for initialization
    void OnEnable()
    {
        textObject = GetComponent<Text>();
        textObject.text = CSVReader.Instance.GetWord(key);
    }
}
