using System;
using System.Collections;
using UnityEngine;

public static class ScriptingUtils  {

    public delegate void Accion(Collider2D other);

	public static IEnumerator showNpcDialogue(NPC npc, bool showTexts)
    {
        if(showTexts)
        {
            yield return ShowNpcMessage(npc);
        }
    }

    public static IEnumerator ShowNpcMessage(NPC npc)
    {
        if (npc.dialogue.Count == 0) yield break;

        DialoguePanel dp = UIManager.Instance.showDialogue("UI/DialoguePanel");

        if(dp!=null)
        {
            foreach(string d in npc.dialogue)
            {
                dp.Show(npc.id, d);

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
        PanelFader pf = UIManager.Instance.createFader("UI/PanelFader");
        if (pf != null)
        {
            yield return pf.StartCoroutine(pf.FadeToBlack());

            UIManager.Instance.Pop();
        }
    }

    public static IEnumerator DoAFadeOut()
    {
        PanelFader pf = UIManager.Instance.createFader("UI/PanelFader");
        if (pf != null)
        {

            yield return pf.StartCoroutine(pf.FadeToClear());

            UIManager.Instance.Pop();
        }
    }


}
