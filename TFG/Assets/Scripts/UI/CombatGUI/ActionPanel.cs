using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {

    public Button buttonAttack;
    public Text textName;
    private CharacterFighter characterFighter;

    void Start()
    {
        buttonAttack.onClick.AddListener(() => Attack());
        textName.text = characterFighter.getBaseStatCharacter().Name;
    }

    

    public void addCharacter(CharacterFighter characterFighter)
    {
        this.characterFighter = characterFighter;
    }

    public void Attack()
    {
        characterFighter.getAnim().SetTrigger("Attack");
    }
}
