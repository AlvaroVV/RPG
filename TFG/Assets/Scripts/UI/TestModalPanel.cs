using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalPanel : MonoBehaviour {


    private CSVReader displayManager;

    //private UnityAction myYesAction;
    //private UnityAction myNoAction;
    //private UnityAction myCancelAction;

    void Awake()
    {
        displayManager = CSVReader.Instance;
        
       // myYesAction = new UnityAction(TestYesFunction);
       // myNoAction = new UnityAction(TestNoFunction);
       // myCancelAction = new UnityAction(TestCancelFunction);
    }

    public void Save()
    {
        SaveLoadManager.SaveSlot();
    }

 
    public void cambiarIdioma(string key)
    {
        CSVReader.Instance.ChangeLanguage(key);
    }
}
