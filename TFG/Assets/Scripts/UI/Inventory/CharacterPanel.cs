using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CharacterPanel : MonoBehaviour, IPointerClickHandler
{

    public Image image;
    public Text text;

    private CharacterData character;
    private ItemData item;

    public void setCharacter(CharacterData character, ItemData item)
    {
        this.character = character;
        this.item = item;
        this.image.sprite = character.face;
        this.text.text = item.GetStadisticText(character);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseCharacterManager.Instance.ApplyEffectOnCharacter(character);
        UpdateText();
    }

    private void UpdateText()
    {
        this.text.text = item.GetStadisticText(character);
    }
}
