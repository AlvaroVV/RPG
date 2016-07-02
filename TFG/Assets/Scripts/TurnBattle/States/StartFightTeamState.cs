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
        tb.ChangeState(tb.StartEnemies);
    }

    public IEnumerator UpdateState()
    {
        Debug.Log("START_TEAM");
        yield return ScriptingUtils.DoAFadeIn();
        FighterActionManager.Instance.CreateFightCursor();//Creamos aqui el Cursor de selección pero DESACTIVADO 
        InstantiateTeam(); // Los creamos aqui para que al empezar la batalla ya estén en posicion.
        MapManager.Instance.GoToFightStage();

        yield return ScriptingUtils.DoAFadeOut();

        yield return null;
    }

    private void InstantiateTeam()
    {
        for (int i = 0; i < tb.PlayerTeam.Count; i++)
        {
            InstantiateCharacter(tb.PlayerTeam[i], tb.CharacterPoints[i]);
        }

        //Creamos el panel CombatGUI y asignamos barras de vida
        CombatGUI.Instance.CreateCharactersPanels(FighterActionManager.Instance.PlayerTeamFighters);
    }

    public void InstantiateCharacter(CharacterData characterData, Transform playerPosition)
    {
        GameObject characObject = Resources.Load("Characters/CharacterFighter") as GameObject;
        GameObject characInstantiate = GameObject.Instantiate(characObject, playerPosition.position, Quaternion.identity) as GameObject;

        CharacterFighter characterFighter = characInstantiate.GetComponent<CharacterFighter>();
        characterFighter.setCharacterProperties(characterData);
        characInstantiate.name = characterData.CharacterName;
        characInstantiate.transform.parent = tb.transform;

        FighterActionManager.Instance.PlayerTeamFighters.Add(characterFighter);
        FighterActionManager.Instance.StackTurnFighter.Add(characterFighter);
    }

}
