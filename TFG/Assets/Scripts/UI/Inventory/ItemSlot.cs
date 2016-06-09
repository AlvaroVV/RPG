using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerDownHandler, IDragHandler , IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Text unitsText;
    public Image itemImage;

    private Stack<ItemData> items;

    private Vector2 offset;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    void Awake()
    {
        items = new Stack<ItemData>();
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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

    public int getUnits()
    {
        return items.Count;
    }

    public void UseItem(BaseCharacter character)
    {
        if (!isEmpty() && items.Peek().CanBeUsed(character))
        {
            ItemData item = items.Pop();
            item.UseItem();
            UpdateUnits();
            InventoryPanel.Instance.items.Remove(item);
            if (isEmpty())
                Destroy(gameObject);
        }
    }

    public void ChargeItemSlot()
    {
        if (getItem().NeedsPanel)
        {
            UIManager.Instance.CreateChooseCharacterPanel(this);
        }
        else
            this.UseItem(null);
    }


    /// <summary>
    /// Callback llamado justo al principio de un click
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Guardamos la referencia al padre por si hay que hacer switch
            InventoryPanel.Instance.SlotChangeFrom = transform.parent.gameObject;
            //Guardamos esta referencia por si no hay slot al que volver ( no se pulsa en un slot ) 
            InventoryPanel.Instance.SlotChangeTo = transform.parent.gameObject;

            offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
            rectTransform.SetParent(transform.parent.parent);
            rectTransform.position = eventData.position - offset;

            //Desactivamos la la interacción del Raycast para poder seleccionar el Slot a través de él
            canvasGroup.blocksRaycasts = false;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
            ChargeItemSlot();
    }

    /// <summary>
    /// Callback llamado mientras se realiza el click o se arrastra
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            rectTransform.position = eventData.position - offset;
    }

    /// <summary>
    /// Callback llamado al acabar el evento
    /// LLamamos al Inventario para que nos diga sobre que Slot se soltó el objeto y 
    /// lo colocamos como padre del ItemSlot
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        ChangeParent(InventoryPanel.Instance.SlotChangeTo.gameObject);  
        //Volvemos a activar la interacción para poder seleccionarlo una vez soltado
        canvasGroup.blocksRaycasts = true;
        
    }

    public void ChangeParent(GameObject slotParent)
    {
        rectTransform.SetParent(slotParent.transform, false);
        rectTransform.position = slotParent.transform.position;
        rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryPanel.Instance.ActivateTooltip(getItem());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryPanel.Instance.DeactivateTooltip();
    }
}
