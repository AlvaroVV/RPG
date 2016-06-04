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
    private ItemSlot itemSlot;

    public void setCharacter(CharacterData character,ref  ItemSlot itemSlot)
    {
        this.character = character;
        this.itemSlot = itemSlot;
        this.image.sprite = character.face;
        this.text.text = itemSlot.getItem().GetStadisticText(character);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemData item = itemSlot.getItem();
        if (item == null)
        {
            Debug.Log("NO QUEDAN OBJETOS");
            Destroy(ChooseCharacterPanel.Instance.gameObject);
        }
        else
        {
            itemSlot.UseItem(character);
            this.text.text = item.GetStadisticText(character);
            ChooseCharacterPanel.Instance.UpdateUnits(itemSlot);
        }
    }

}
