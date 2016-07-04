using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialoguePanel: MonoBehaviour  {

    public Text Title;
    public Text BodyText;
    public Image image;

    public IEnumerator Show(string title, string body)
    {
        image.gameObject.SetActive(false);

        if (title!=null)
            Title.text = title;
        int i = 0;
        string str = "";
        while(i<body.Length)
        {
            str += body[i];
            BodyText.text = str;
            i++;
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    public void Show(string title, string body, Sprite image)
    {
        if (title != null)
            Title.text = title;
        BodyText.text = body;
        this.image.sprite = image;
    }

}
