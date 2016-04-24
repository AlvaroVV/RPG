using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FadeCombatText : MonoBehaviour {

    public Color color;
    public string text;
    public float speed = 0.5f;
    public float fadeTime = 1;
    public Vector3 direction = Vector3.up;

    public Text TextComponent { get; set; }

    void Start()
    {
        TextComponent = GetComponent<Text>();
        TextComponent.color = color;
        TextComponent.text = text;
        StartCoroutine(TextEffect());
    }

    public IEnumerator TextEffect()
    {
        Color resetColor = TextComponent.color;
        resetColor.a = 1;
        TextComponent.color = resetColor;

        yield return new WaitForSeconds(fadeTime);

        while (TextComponent.color.a > 0)
        {
            Color displayColor = TextComponent.color;
            displayColor.a -= Time.deltaTime / fadeTime;
            TextComponent.color = displayColor;
            yield return null;
        }
        yield return null;
        Destroy(gameObject);
    }

    void Update()
    {
        float translation = speed * Time.deltaTime;
        transform.Translate(direction * translation);
    }
}
