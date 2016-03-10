using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StartfightTeamState : IState
{

    TurnBattleHandler tb;

    public StartfightTeamState(TurnBattleHandler tb)
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
        GameGlobals.camera.GoToFightStage(GameObject.FindGameObjectWithTag(GameGlobals.TagFightStage));
        GameGlobals.BackReference.gameObject.SetActive(false);

        yield return ScriptingUtils.DoAFadeOut();

        //Guardamos la lista de enemigos
        tb.enemyDatas = new List<EnemyData>(tb.enemy.EnemyTeam);
        //Destruimos la IA del enemigo
        tb.Destroy(tb.enemy.gameObject);

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

    public void InstantiateCharacter(BaseStatCharacter characterData, Transform playerPosition)
    {

        GameObject characObject = Resources.Load("Characters/CharacterFighter") as GameObject;
        GameObject characInstantiate = GameObject.Instantiate(characObject, playerPosition.position, Quaternion.identity) as GameObject;

        CharacterFighter characterFighter = characInstantiate.GetComponent<CharacterFighter>();
        characterFighter.setCharacterProperties(characterData);
        characInstantiate.name = characterData.name;
        characInstantiate.transform.parent = tb.transform;

        tb.playerTeamFighters.Add(characInstantiate);
        tb.stackTurnfighter.Add(characterFighter);
    }
}
