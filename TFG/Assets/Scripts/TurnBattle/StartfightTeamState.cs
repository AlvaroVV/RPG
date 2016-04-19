using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StartFightTeamState : IState
{

    TurnBattleHandler tb;

    public StartFightTeamState(TurnBattleHandler tb)
    {
        this.tb = tb;
    }
    public void changeState()
    {
        tb.ChangeState(tb.startEnemies);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("START_TEAM");
        yield return ScriptingUtils.DoAFadeIn();

        InstantiateTeam(); // Los creamos aqui para que al empezar la batalla ya estén en posicion.
        CreateFightCursor();//Creamos aqui el Cursor de selección pero DESACTIVADO 
        GameGlobals.camera.GoToFightStage(GameObject.FindGameObjectWithTag(GameGlobals.TagFightStage));
        GameGlobals.BackReference.gameObject.SetActive(false);

        yield return ScriptingUtils.DoAFadeOut();

        yield return null;
    }

    private void InstantiateTeam()
    {
        for (int i = 0; i < tb.playerTeam.Count; i++)
        {
            InstantiateCharacter(tb.playerTeam[i], tb.CharacterPoints[i]);
        }

        //Creamos el panel CombatGUI y asignamos barras de vida
        UIManager.Instance.CreateCombatGUI("UI/CombatGUI");
        CombatGUI.Instance.CreateCharactersPanels(tb.playerTeamFighters);
    }

    public void InstantiateCharacter(CharacterData characterData, Transform playerPosition)
    {
        GameObject characObject = Resources.Load("Characters/CharacterFighter") as GameObject;
        GameObject characInstantiate = GameObject.Instantiate(characObject, playerPosition.position, Quaternion.identity) as GameObject;

        CharacterFighter characterFighter = characInstantiate.GetComponent<CharacterFighter>();
        characterFighter.setCharacterProperties(characterData,tb);
        characInstantiate.name = characterData.CharacterName;
        characInstantiate.transform.parent = tb.transform;

        tb.playerTeamFighters.Add(characterFighter);
        tb.stackTurnfighter.Add(characterFighter);
    }

    public void CreateFightCursor()
    {
        GameObject cursorRes = Resources.Load("UI/Cursor") as GameObject;
        GameObject cursorObj = GameObject.Instantiate(cursorRes, tb.transform.position, Quaternion.identity) as GameObject;
        cursorObj.transform.parent = tb.transform;
        tb.cursor = cursorObj.GetComponent<Cursor>();
        tb.cursor.gameObject.SetActive(false);
    }
}
