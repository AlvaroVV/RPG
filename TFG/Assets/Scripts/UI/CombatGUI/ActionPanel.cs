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
        CharacterData data = characterFighter.FighterData as CharacterData;
        textName.text = data.Name;
        image.sprite = data.face;
    }

    public void SetAction(BaseAttack attackInfo)
    {
        //Guardamos la info del ataque elegido
        FighterActionManager.Instance.attackInfo = attackInfo;
        //Elegimos el primer enemigo
        FighterActionManager.Instance.TargetFirstEnemy();
        //Desactivamos el panel
        gameObject.SetActive(false);
    }

    public BaseAttack Attack()
    {
        return characterFighter.FighterData.normalAttack;
    }


}
