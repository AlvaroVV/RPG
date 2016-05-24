using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public Text slotText;
    public GameObject itemPref;

    private Stack<ItemData> items;

	// Use this for initialization
	void Awake() {
        items = new Stack<ItemData>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddItem(ItemData item)
    {
        items.Push(item);

        GameObject itemObj = Instantiate(itemPref) as GameObject;
        itemObj.GetComponent<Image>().sprite = item.image;
        addChild(itemObj, gameObject);

        if(items.Count>1)
        {
            slotText.text = items.Count.ToString();
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
}
