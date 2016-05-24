using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class UIManager: MonoBehaviour  {

    private List<GameObject> panelStack; //Pila de paneles
    
    public static UIManager instance = null;
    public static UIManager Instance    
    {
        get
        {
            return instance;
        }
    }

    private UIManager() { }

    void Awake()
    {
        instance = this;
        panelStack = new List<GameObject>();
    }

    public GameObject Push(string panelPrefabName)
    {
        //Si ya existe el panel no creamos otro
        GameObject panel = panelStack.Where(x => x.name.Equals(panelPrefabName)).SingleOrDefault();
        if (panel != null)
        {   
            return panel;
        }
        GameObject loadPanel = Resources.Load(panelPrefabName) as GameObject;
        //Si lo cargamos y no lo encontramos lanzamos Error
        if (loadPanel == null) {
            Debug.LogError("Panel not found -> " + panelPrefabName);
            return null;
        }

        loadPanel = addChild(loadPanel);
        loadPanel.name = panelPrefabName;
        loadPanel.SetActive(true);
       
        panelStack.Add(loadPanel);
        

        return loadPanel;
    }

    public void Pop()
    {
        if (panelStack.Count > 0)
        {
            GameObject lastPanel = panelStack[panelStack.Count - 1];

            lastPanel.gameObject.SetActive(false);
            lastPanel.transform.SetParent(null);
            panelStack.RemoveAt(panelStack.Count - 1);
            Destroy(lastPanel);
        }
    }
    

    private GameObject addChild(GameObject child)
    {
        GameObject panel = GameObject.Instantiate(child, child.transform.position, child.transform.rotation) as GameObject;
        if (panel != null)
        {
            Transform t = panel.transform;
            t.SetParent(gameObject.transform, false);
            //t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            panel.layer = gameObject.layer;

        }
        return panel;
        
    }

    private GameObject addChild(GameObject child, GameObject parent)
    {
        GameObject panel = GameObject.Instantiate(child, child.transform.position, child.transform.rotation) as GameObject;
        if (panel != null)
        {
            Transform t = child.transform;
            t.parent = parent.transform;
            //t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            
            panel.layer = parent.layer;
        }
        return panel;
    }

    public DialoguePanel showDialogue(string dialogPrefabName)
    {
        GameObject panel = Push(dialogPrefabName);
        DialoguePanel dialoguePanel = panel.GetComponent<DialoguePanel>();

        return dialoguePanel;
    }

    public PanelFader createFader(string faderName)
    {
        GameObject fader = Push(faderName);
        PanelFader pf = fader.GetComponent<PanelFader>();

        return pf;
    }

    public CombatGUI CreateCombatGUI(string combatGUIName)
    {
        GameObject combatGUI = Push(combatGUIName);
        CombatGUI combat = combatGUI.GetComponent<CombatGUI>();

        return combat;
    }

    public InventoryPanel CreateInventoryPanel()
    {
        GameObject inventoryObj = Push("UI/InventoryPanel");
        InventoryPanel inventory = inventoryObj.GetComponent<InventoryPanel>();
        inventoryObj.gameObject.SetActive(false);
        return inventory;
    }

}
