using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour,IDropHandler {

    public GameObject itemPref;

    private GameObject itemSlot;
	
    public void AddItem(ItemData item)
    {
        if (itemSlot == null)
        {
            itemSlot = Instantiate(itemPref);
            itemSlot.name = "item_" + item.name;
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
        ItemSlot itemSlotFrom = eventData.pointerDrag.GetComponent<ItemSlot>();

        //Si este slot ya tiene un Item, hay que hacer un cambio
        if (itemSlot != null)
        {
            ItemSlot itemSlotTo = itemSlot.GetComponent<ItemSlot>();

            //Cambiamos el slot de este item por el que movemos
            itemSlotTo.ChangeParent(InventoryPanel.Instance.SlotChangeFrom);
            InventoryPanel.Instance.SlotChangeFrom.GetComponent<Slot>().itemSlot = itemSlotTo.gameObject;

        }
        else
        {
            //Si no tiene un item, el slot del que proviene se queda vacío
            InventoryPanel.Instance.SlotChangeFrom.GetComponent<Slot>().itemSlot = null;
        }

        itemSlot = itemSlotFrom.gameObject;

    }

    public void ChangeItemslot(GameObject item)
    {
        this.itemSlot = item;
    }
}
