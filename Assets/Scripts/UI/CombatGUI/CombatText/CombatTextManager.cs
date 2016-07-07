using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatTextManager : MonoBehaviour {

    public FadeCombatText HealthText;
    public BounceCombatText BounceText;

    private RectTransform rectTransform;
    private static CombatTextManager instance;

    public static CombatTextManager Instance
    {
        get
        { 
            return instance;

        }
    }

    void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
    }

    public GameObject CreateHealthText(Vector3 position, int number)
    {
        HealthText.number = number;
        GameObject TextObj = Instantiate(HealthText.gameObject, position, Quaternion.identity) as GameObject;
        TextObj.transform.SetParent(rectTransform);
        TextObj.transform.localScale = Vector3.one;

        return TextObj;
    }

    public GameObject CreateBounceText(Vector3 position, int number)
    {
        BounceText.number = number;
        GameObject TextObj = Instantiate(BounceText.gameObject, position, Quaternion.identity) as GameObject;
        TextObj.transform.SetParent(rectTransform);
        TextObj.transform.localScale = Vector3.one;
        return TextObj;
    }
}
