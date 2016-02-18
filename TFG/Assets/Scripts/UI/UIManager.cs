using UnityEngine;
using System.Collections;

public class UIManager: MonoBehaviour  {

    public static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    //Referencias a los paneles
    private DialoguePanel dPanel;

    private UIManager() { }

    void Awake()
    {
        instance = this;
        dPanel = DialoguePanel.Instance();
    }

    public void showDialog(string dialogue)
    {
        dPanel.writeMessage(dialogue);
    }

    public void closeDialogWindow()
    {
        dPanel.closePanel();
    }

    public void writeTitle(string title)
    {
     
        dPanel.writeTitle(title);
    }

}
