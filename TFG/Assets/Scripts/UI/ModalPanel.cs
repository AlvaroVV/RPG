using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text question;
    public Image iconImage;
    public Button yesButton;
    public Button noButton;
    public Button cancelButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if(!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("No hay ningun Modal Panel script en ningún objeto");
        }

        return modalPanel;
    }

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);

        BotonYesClick(yesEvent);
        BotonNoClick(noEvent);
        BotonCancelClick(cancelEvent);

        this.question.text = question;

        ActivateObjects(false, true, true, true);
    }

    public void Choice(string question, Sprite icon, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);
        iconImage.sprite = icon;

        BotonYesClick(yesEvent);
        BotonNoClick(noEvent);
        BotonCancelClick(cancelEvent);

        this.question.text = question;

        ActivateObjects(true, true, true, true);
    }

    void BotonYesClick(UnityAction yesEvent)
    {
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(yesEvent);
        yesButton.onClick.AddListener(ClosePanel);
    }

    void BotonNoClick(UnityAction noEvent)
    {
        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(noEvent);
        noButton.onClick.AddListener(ClosePanel);
    }

    void BotonCancelClick(UnityAction cancelEvent)
    {
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(cancelEvent);
        cancelButton.onClick.AddListener(ClosePanel);
    }

    void ActivateObjects(bool image, bool yes, bool no, bool cancel)
    {
        this.iconImage.gameObject.SetActive(image);
        yesButton.gameObject.SetActive(yes);
        noButton.gameObject.SetActive(no);
        cancelButton.gameObject.SetActive(cancel);
        
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }

}
