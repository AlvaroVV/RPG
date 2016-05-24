using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    public GameObject SlotsPanel;
    public GameObject slotObj;
    public int SlotAmount;

    public List<GameObject> inventorySlots { get; set; }
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
        inventorySlots = new List<GameObject>();
        items = new List<ItemData>();
    }

    // Use this for initialization
    void Start () {

        ChargeInventory();
	
	}

    private void ChargeInventory()
    {
        for (int i = 0; i < SlotAmount; i++)
        {
            GameObject slotObj = Instantiate(this.slotObj, SlotsPanel.transform.position, SlotsPanel.transform.rotation) as GameObject;
            inventorySlots.Add(slotObj);
            addChild(slotObj, SlotsPanel);

            if(i<items.Count)
            {
                Slot slot = slotObj.GetComponent<Slot>();
                slot.AddItem(items[i]);
            }
        }
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

    // Update is called once per frame
    void Update () {
	
	}
}
