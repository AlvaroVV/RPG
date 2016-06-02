using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    public GameObject SlotsPanel;
    public GameObject slotObj;
    public int SlotAmount;

    public List<Slot> inventorySlots { get; set; }
    public List<ItemData> items { get; set; }

    private static InventoryPanel instance = null;
    public static InventoryPanel Instance
    {
        get
        {
            return instance;
        }
    }


    void Awake()
    {
        instance = this;
        inventorySlots = new List<Slot>();
        items = new List<ItemData>();
    }

    // Use this for initialization
    void Start () {

        ChargeSlots();
        ChargeInventory();
	}

    private void ChargeSlots()
    {
        for (int i = 0; i < SlotAmount; i++)
        {
            GameObject slotObj = Instantiate(this.slotObj, SlotsPanel.transform.position, SlotsPanel.transform.rotation) as GameObject;
            inventorySlots.Add(slotObj.GetComponent<Slot>());
            addChild(slotObj, SlotsPanel);
        }
    }

    private void ChargeInventory()
    {
        foreach(ItemData item in items)
        {
            Slot slot = LookForSlot(item);
            if (slot != null)
                slot.AddItem(item);
        }
    }

    private Slot LookForSlot(ItemData item)
    {
        //Buscamos un slot con ese Item
        foreach(Slot slot in inventorySlots)
        {
            if (slot.getItemSlotName().Equals(item.name))
                return slot;
        }

        //Si no existe un slot con ese item devolvemos uno vacío
        foreach (Slot slot in inventorySlots)
        {
            if (slot.isEmpty())
                return slot;
        }

        return null;
    }
    
    public void AddSlotItem(ItemData item)
    {
        Slot slot = LookForSlot(item);
        if (slot != null)
            slot.AddItem(item);
        else
            Debug.Log("El Inventario está lleno");
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

}
