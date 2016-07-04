using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CharacterPanel : MonoBehaviour, IPointerClickHandler
{

    public Image characterImage;
    public Text stadisticText;

    private CharacterData character;
    private ItemSlot itemSlot;

    public void SetProperties(CharacterData character, ItemSlot itemSlot)
    {
        this.character = character;
        this.itemSlot = itemSlot;
        characterImage.sprite = character.face;
        stadisticText.text = itemSlot.GetItem().GetStadisticText(character);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ApplyItemEffect();
    }

    private void ApplyItemEffect()
    {
      
        if (itemSlot.isEmpty())
        {
            UIManager.Instance.RemovePanel(ChooseCharacterPanel.Instance.gameObject);
        }
        else
        {
            ItemData item = itemSlot.GetItem();

            if (item.ConditionToUse(character))
            {                
                item.ApplyEffect(character);
                itemSlot.UpdateUnits();                
                stadisticText.text = item.GetStadisticText(character);
                ChooseCharacterPanel.Instance.UpdateUnits(itemSlot);
            }

        }
    }


}
