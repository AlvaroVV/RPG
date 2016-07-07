using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {

    public Button buttonAttack;
    public Button buttonSpecial;
    public Text textName;
    public Image CharacterImage;
    private CharacterFighter characterFighter;


    public void addCharacter(CharacterFighter characterFighter)
    {
        this.characterFighter = characterFighter;
        buttonAttack.onClick.AddListener(() => SetAction(Attack()));
        buttonSpecial.onClick.AddListener(() => SetAction(Special()));
        createStats();
    }

    private void createStats()
    {
        CharacterData data = characterFighter.FighterData as CharacterData;
        textName.text = data.Name;
        CharacterImage.sprite = data.face;
        if (data.specialAttack != null)
        {
            buttonSpecial.gameObject.SetActive(true);
            buttonSpecial.GetComponentInChildren<Text>().text = data.specialAttack.NameAttack;
        }
    }

    public void SetAction(BaseAttack attackInfo)
    {
        if (attackInfo.canBeUsed(characterFighter))
        {
            //Guardamos la info del ataque elegido
            FighterActionManager.Instance.attackInfo = attackInfo;
            //Elegimos el primer enemigo
            FighterActionManager.Instance.TargetFirstEnemy();
            //Desactivamos el panel
            gameObject.SetActive(false);
        }
    }

    public BaseAttack Special()
    {
        if(characterFighter.FighterData.specialAttack != null)
            return characterFighter.FighterData.specialAttack;
        return null;
    }

    public BaseAttack Attack()
    {
        return characterFighter.FighterData.normalAttack;
    }


}
