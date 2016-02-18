using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialoguePanel: MonoBehaviour  {

    public Text Title;
    public Text BodyText;
    public GameObject dialoguePanelObject;

    private static DialoguePanel dPanel;

    public static DialoguePanel Instance()
    {
        if (!dPanel)
        {
            dPanel = FindObjectOfType(typeof(DialoguePanel)) as DialoguePanel;
            if (!dPanel)
                Debug.LogError("No hay ningun Dialogue Panel script en ningún objeto");
        }

        return dPanel;
    }


    public void writeTitle(string message)
    {
        dialoguePanelObject.SetActive(true);
        Title.text = message;
    }

    public void writeMessage(string message)
    {
        BodyText.text = message;
    }

    public void closePanel()
    {
        dialoguePanelObject.SetActive(false);
    }
}
