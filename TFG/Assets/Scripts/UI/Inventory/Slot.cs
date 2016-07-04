using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour,IDropHandler {

    public GameObject itemPref;

    private GameObject itemSlot;
	
    public void AddItemSlot(ItemData item)
    {
        if (itemSlot == null)
        {
            itemSlot = Instantiate(itemPref);
            itemSlot.name = "item_" + item.name;
            ScriptingUtils.addChild(itemSlot, gameObject);
        }

        itemSlot.GetComponent<ItemSlot>().AddItem(item);
    }

    public void AddItemSlot(Stack<ItemData> items)
    {
        if (itemSlot == null)
        {
            itemSlot = Instantiate(itemPref);
            ScriptingUtils.addChild(itemSlot, gameObject);
        }

        itemSlot.GetComponent<ItemSlot>().AddItem(items);

    }

   
    public bool isEmpty()
    {
        return (itemSlot == null) ? true : false;
    }

    public GameObject GetItemSlot()
    {
        return itemSlot;
    }

    public string getItemSlotName()
    {
        if (itemSlot != null)
            return itemSlot.GetComponent<ItemSlot>().GetItemName();
        else
            return "";
    }

    /// <summary>
    /// Callback llamado cuando un objeto es "soltado" al ser arrastrado.
    /// Se llama antes que el EndDragHandler
    /// </summary>
    /// <param name="eventData">Datos del evento, como el objeto "soltado"</param>
    public void OnDrop(PointerEventData eventData)
    {
        //El slot a cambiar
        InventoryPanel.Instance.SlotChangeTo = gameObject;

        //ItemSlot que se va a mover
        InventoryPanel.Instance.ChangeItemPositions();

    }

    public void ChangeItemSlot(GameObject itemSlot)
    {
        this.itemSlot = itemSlot;
    }


}
