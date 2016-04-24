using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BounceCombatText : MonoBehaviour
{
    public Color color;
    public int number;
    public AnimationClip clip;

    private Text textComponent;
    private bool playingClip = true;
    void Start()
    {
        textComponent = GetComponentInChildren<Text>();
        textComponent.color = color;
        textComponent.text = number.ToString();
        StartCoroutine(TextEffect());
    }

    public IEnumerator TextEffect()
    {
        StartCoroutine(generateRandomNumber());
        yield return new WaitForSeconds(clip.length);
        playingClip = false;
        textComponent.text = number.ToString(); 
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public IEnumerator generateRandomNumber()
    {
        while(playingClip)
        {
            int random = Random.Range(number / 2, number + number / 2);
            textComponent.text = random.ToString();
            yield return null;
        }
    }


}
