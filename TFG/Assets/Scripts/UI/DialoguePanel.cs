using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialoguePanel: MonoBehaviour  {

    public Text Title;
    public Text BodyText;

    public void Show(string title, string body)
    {
        if(title!=null)
            Title.text = title;
        BodyText.text = body;
    }

}
