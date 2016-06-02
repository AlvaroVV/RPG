using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler {

    public Text unitsText;
    public Image itemImage;

    private Stack<ItemData> items;

    void Awake()
    {
        items = new Stack<ItemData>();
    }


    public void AddItem(ItemData item)
    {
        items.Push(item);

        //Solo añadimos un item como hijo
        if (items.Count == 1)
        {
            itemImage.sprite = item.image;
        }
        else if (items.Count > 1)
        {
            unitsText.text = items.Count.ToString();
        }
    }

    public void AddItems(Stack<ItemData> items)
    {
        items = new Stack<ItemData>();

        if (items.Count > 1) unitsText.text = items.Count.ToString();
    }


    public ItemData getItem()
    {
        if (!isEmpty())
            return items.Peek();
        return null;

    }

    public string getItemName()
    {
        if (!isEmpty())
            return items.Peek().name;
        return "";

    }

    public bool isEmpty()
    {
        return (items.Count > 0) ? false : true;
    }

    public void UpdateUnits()
    {
        unitsText.text = (items.Count > 1) ? items.Count.ToString() : string.Empty;
    }

    public void UseItem(BaseCharacter character)
    {
        if (!isEmpty() && items.Peek().CanBeUsed(character))
        {
            items.Pop().UseItem();
            UpdateUnits();
            if (isEmpty())
                Destroy(gameObject);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            this.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
