using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScriptingUtils  {

    public static IEnumerator showInformation(string information)
    {
        DialoguePanel dp = UIManager.Instance.showDialogue("UI/DialoguePanel");

        if (dp != null)
        {

           yield return dp.ShowInformation(information);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            yield return null;

        }
            UIManager.Instance.Pop();
        
    }
   
	public static IEnumerator showNpcDialogue(NPC npc, bool showTexts)
    {
        if(showTexts)
        {
            yield return ShowSentences(npc.NPC_name, npc.dialogue);
        }
    }

    public static IEnumerator ShowSentences(string name, List<string> sentence)
    {
        if (sentence.Count == 0) yield break;

        DialoguePanel dp = UIManager.Instance.showDialogue("UI/DialoguePanel");

        if(dp!=null)
        {
            foreach(string d in sentence)
            {
                yield return dp.Show(name, d);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

                yield return null; 
            }

            UIManager.Instance.Pop();
        }

    }

    public static IEnumerator ShowDialogue(List<string[]> dialogue)
    {
        if (dialogue.Count == 0) yield break;

        DialoguePanel dp = UIManager.Instance.showDialogue("UI/DialoguePanel");

        if (dp != null)
        {
            foreach (string[] d in dialogue)
            {
                yield return dp.Show(d[0], d[1]);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

                yield return null;
            }

            UIManager.Instance.Pop();
        }

    }

    public static IEnumerator DoAFadeIn()
    {
        PanelFader pf = UIManager.Instance.createFader();
        if (pf != null)
        {
            yield return pf.FadeToBlack();

            UIManager.Instance.Pop();
        }
    }

    public static IEnumerator DoAFadeOut()
    {
        PanelFader pf = UIManager.Instance.createFader();

        if (pf != null)
        {
            yield return pf.FadeToClear();

            Debug.Log("AQUI");
            UIManager.Instance.Pop();
        }
    }

    public static IEnumerator WaitForKeyPressed(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }

        yield return null;
    }


    public static void addChild(GameObject child, GameObject parent)
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
