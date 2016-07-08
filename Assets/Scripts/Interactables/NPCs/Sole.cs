using UnityEngine;
using System.Collections;

public class Sole : WalkerNPC {

    void Start()
    {
        NPC_name = "Sole";
    }

    public override IEnumerator SpecialInteract()
    {
        yield return GameGlobals.GetPlayerLoader().GetCurrentChapter().InteractZack();
        yield return null;
    }
}
