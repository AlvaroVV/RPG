using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTeamController  {

    public List<BaseStatCharacter> team { get; set; }

	public void AddCharacter(BaseStatCharacter character)
    {
        team.Add(character);
    }

}
