using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
        if (panelStack.Count > 0 && panelStack[panelStack.Count - 1].gameObject.name == panelPrefabName) return null;
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
            lastPanel.transform.parent = null;
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

    

}
