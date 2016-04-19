using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController  {

    public List<CharacterData> team { get; set; }

	public void AddCharacter(CharacterData character)
    {
        team.Add(character);
    }

}
