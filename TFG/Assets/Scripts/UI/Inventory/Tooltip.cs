using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    public Text text;

    private ItemData itemData;

    void Start()
    {
        gameObject.SetActive(false);

    }

    void Update()
    {
        if(gameObject.activeSelf)
            transform.position = Input.mousePosition;
    }

	public void Activate(ItemData item)
    {
        this.itemData = item;
        gameObject.SetActive(true);
        ConstructDataString();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void ConstructDataString()
    {
        text.text = "<color=#0473f0><b>" + itemData.id + "</b></color> \n\n"+ itemData.Description +"";

    }
}
