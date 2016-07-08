using UnityEngine;
using System.Collections;

public class Zack : WalkerNPC {

    void Start()
    {
        NPC_name = "Zack";
    }

    public override IEnumerator SpecialInteract()
    {
        yield return GameGlobals.GetPlayerLoader().GetCurrentChapter().InteractZack();
        yield return null;
    }
}
