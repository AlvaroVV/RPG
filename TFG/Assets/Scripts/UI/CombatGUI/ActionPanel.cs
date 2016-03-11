using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {

    public Button buttonAttack;
    public Text textName;
    public Image image;
    private CharacterFighter characterFighter;
    private FighterAction action; 


    public void addCharacter(CharacterFighter characterFighter)
    {
        this.characterFighter = characterFighter;
        buttonAttack.onClick.AddListener(() => CreateAction(Attack));
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

    public void CreateAction(Action actionAttack)
    {
        action = new FighterAction(actionAttack);
    }

    public IEnumerator waitForAttack()
    {
        while(action == null)
        {
            yield return null;
        }
    }

    public void ExecuteAction()
    {
        action.ExecuteAction();
    }
}
