using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerClickHandler {

    public GameObject itemPref;

    private GameObject itemSlot;
	
    public void AddItem(ItemData item)
    {
        if (itemSlot == null)
        {
            itemSlot = Instantiate(itemPref);
            addChild(itemSlot, gameObject);
        }

        itemSlot.GetComponent<ItemSlot>().AddItem(item);
    }

    public void AddItems(Stack<ItemData> items)
    {
        if (itemSlot == null)
        {
            itemSlot = Instantiate(itemPref);
            addChild(itemSlot, gameObject);
        }

        itemSlot.GetComponent<ItemSlot>().AddItems(items);

    }

    private void addChild(GameObject child, GameObject parent)
    {
        if (child != null)
        {
            Transform t = child.transform;
            t.SetParent(parent.transform, false);
            //t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            child.layer = parent.layer;
        }
        
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
            ChargeSlot();
    }

    private void ChargeSlot()
    {
        if (itemSlot != null)
        {   
            ChooseCharacterManager.Instance.ChargeSlot(itemSlot.GetComponent<ItemSlot>());            
        }
    }

    public bool isEmpty()
    {
        return (itemSlot == null) ? true : false;
    }

    public string getItemSlotName()
    {
        if (itemSlot != null)
            return itemSlot.GetComponent<ItemSlot>().getItemName();
        else
            return "";
    }

}
