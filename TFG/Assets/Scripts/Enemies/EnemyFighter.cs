using UnityEngine;
using System.Collections;

public class EnemyFighter : MonoBehaviour {

    private Animator anim;
    private EnemyData enemyData;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setEnemyProperties(EnemyData enemyData)
    {
        if(enemyData != null)
        {
            anim = GetComponent<Animator>();
            this.enemyData = enemyData;
            anim.runtimeAnimatorController = enemyData.animatorController;
        }            
    }
}
