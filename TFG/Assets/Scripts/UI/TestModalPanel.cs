using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalPanel : MonoBehaviour {

    public Text displayText;
    public GameObject panelText;
    public Sprite iconImage;

    private ModalPanel modalPanel;
    private CSVReader displayManager;

    //private UnityAction myYesAction;
    //private UnityAction myNoAction;
    //private UnityAction myCancelAction;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = CSVReader.Instance;
        
       // myYesAction = new UnityAction(TestYesFunction);
       // myNoAction = new UnityAction(TestNoFunction);
       // myCancelAction = new UnityAction(TestCancelFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void TestYNC()
    {
        modalPanel.Choice(CSVReader.Instance.GetWord("Saludo1"), TestYesFunction, TestNoFunction, TestCancelFunction);
        //modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myCancelAction);
    }

    public void TestYNCImage()
    {
        modalPanel.Choice(CSVReader.Instance.GetWord("Saludo1"), iconImage ,TestYesFunction, TestNoFunction, TestCancelFunction);
        //modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myCancelAction);
    }

    //  These are wrapped into UnityActions
    void TestYesFunction()
    {
        //displayManager.DisplayMessage("Heck yeah! Yup!");
        panelText.SetActive(true);
        displayText.text = displayManager.GetWord("Saludo1");
    }

    void TestNoFunction()
    {
        //displayManager.DisplayMessage("No way, José!");
        panelText.SetActive(true);
        displayText.text = displayManager.GetWord("Hola");
    }

    void TestCancelFunction()
    {
        //displayManager.DisplayMessage("I give up!");
        panelText.SetActive(true);
        displayText.text = displayManager.GetWord("Adiós");
    }

    public void cambiarIdioma(string key)
    {
        CSVReader.Instance.ChangeLanguage(key);
    }
}
