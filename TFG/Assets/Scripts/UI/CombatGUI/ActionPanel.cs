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
        buttonAttack.onClick.AddListener(() => SetAction(Attack()));
        createStats();
    }

    private void createStats()
    {
        textName.text = characterFighter.getCharacterData().Name;
        image.sprite = characterFighter.getCharacterData().face;
    }

    public AttackInfo Attack()
    {
        return characterFighter.getCharacterData().normalAttack;
    }

    public void SetAction(AttackInfo attackInfo)
    {
        characterFighter.fighterAction.setAttack(attackInfo);
    }

}
