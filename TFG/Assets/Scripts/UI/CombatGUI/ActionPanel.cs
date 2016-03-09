using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {

    public Button buttonAttack;
    public Text textName;
    public Image image;
    private CharacterFighter characterFighter;

   
    public void addCharacter(CharacterFighter characterFighter)
    {
        this.characterFighter = characterFighter;
        buttonAttack.onClick.AddListener(() => Attack());
        createStats();
    }

    private void createStats()
    {
        textName.text = characterFighter.getBaseStatCharacter().Name;
        image.sprite = characterFighter.getBaseStatCharacter().face;
    }

    public void Attack()
    {
        characterFighter.getAnim().SetTrigger("Attack");
    }
}
