using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class FinishBattleState : IState
{
    private TurnBattleHandler tb;

    private string Information;

    public FinishBattleState(TurnBattleHandler tb)
    {
        this.tb = tb;
        Information = CSVReader.Instance.GetWord("ItemSpawn");
    }


    public IEnumerator UpdateState()
    {
        yield return ShowItemsWon();
        yield return ScriptingUtils.WaitForKeyPressed(KeyCode.Space);
        MapManager.Instance.GetActualMap().GetAudioSource().PlayAmbientSound();
    }

    public void changeState()
    {     
        tb.CleanAndFinish();

    }

    private IEnumerator ShowItemsWon()
    {
        List<ItemData> ItemsToWin = FighterActionManager.Instance.ItemsToWin;
        int random = UnityEngine.Random.Range(0, ItemsToWin.Count-1);
        yield return GiveItem(ItemsToWin[random]);

    }

    private IEnumerator GiveItem(ItemData item)
    {
        yield return ScriptingUtils.showInformation(Information += " " + "<color=#0473f0>" + item.Id + "</color>");
        GameGlobals.GetPlayerTeamController().AddItemData(item);
    }

}
