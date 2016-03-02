using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyTeam : MonoBehaviour {

    public List<GameObject> enemyTeam;

    public bool RandomFighters = false;
    public int numberOfFighters = 1;

    void Awake()
    {
        enemyTeam = new List<GameObject>();
    }

	public List<GameObject> getEnemyTeam()
    {
        if(RandomFighters)
        {
            enemyTeam = getRandomFighters();
        }
        if(numberOfFighters < enemyTeam.ToArray().Length)
        {
            enemyTeam = shortEnemyTeam();
        }

        return enemyTeam;
    } 

    private List<GameObject> getRandomFighters()
    {
       return enemyTeam;
    }

    private List<GameObject> shortEnemyTeam()
    {
        return enemyTeam;
    }
}
