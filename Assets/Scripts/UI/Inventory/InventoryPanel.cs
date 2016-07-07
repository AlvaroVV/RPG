using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    public GameObject SlotsPanel;
    public GameObject slotObj;
    public GameObject Tooltip;
    public int SlotAmount;

    public List<Slot> inventorySlots { get; set; }
    public List<ItemData> items { get; set; }

    public GameObject SlotChangeTo { get; set; }
    public GameObject SlotChangeFrom { get; set; }

    private Tooltip tooltip;

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
        items = GameGlobals.GetPlayerTeamController().items;

        ChargeSlots();
        ChargeInventory();
        CreateTooltip();
	}

    private void ChargeSlots()
    {
        for (int i = 0; i < SlotAmount; i++)
        {
            GameObject slotObj = Instantiate(this.slotObj, SlotsPanel.transform.position, SlotsPanel.transform.rotation) as GameObject;
            inventorySlots.Add(slotObj.GetComponent<Slot>());
            ScriptingUtils.addChild(slotObj, SlotsPanel);
        }
    }

    private void ChargeInventory()
    {

        foreach(ItemData item in items)
        {
            Slot slot = LookForSlot(item);
            if (slot != null)
                slot.AddItemSlot(item);
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
            slot.AddItemSlot(item);
        else
            Debug.Log("El Inventario está lleno");
    }

    public void ChangeItemPositions()
    {
        //Slots que participan
        Slot slotFrom = SlotChangeFrom.GetComponent<Slot>();
        Slot slotTo = SlotChangeTo.GetComponent<Slot>();

        //ItemsSlots que participan
        ItemSlot itemSlotFrom = slotFrom.GetItemSlot().GetComponent<ItemSlot>();
        ItemSlot itemSlotTo = null;

        GameObject itemSlotObj = slotTo.GetItemSlot();

        if(itemSlotObj != null)
            itemSlotTo = itemSlotObj.GetComponent<ItemSlot>();
        
        //Si este slot ya tiene un Item, hay que hacer un cambio
        if (itemSlotTo != null)
        {        
            //Cambiamos el slot de este item por el que movemos
            itemSlotTo.ChangeParent(SlotChangeFrom);
            slotFrom.ChangeItemSlot(itemSlotTo.gameObject);
        }
        else
        {
            //Si no tiene un item, el slot del que proviene se queda vacío
            slotFrom.ChangeItemSlot(null);
        }
        slotTo.ChangeItemSlot(itemSlotFrom.gameObject);
    }

    private void CreateTooltip()
    {
        GameObject tooltipObj = Instantiate(Tooltip.gameObject) as GameObject;
        ScriptingUtils.addChild(tooltipObj, gameObject);
        tooltip = tooltipObj.GetComponent<Tooltip>();
    }

    public void ActivateTooltip(ItemData item)
    {
        tooltip.Activate(item);
    }

    public void DeactivateTooltip()
    {
        tooltip.Deactivate();
    }
    


}
