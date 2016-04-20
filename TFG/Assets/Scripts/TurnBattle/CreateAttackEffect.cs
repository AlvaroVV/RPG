using UnityEngine;
using System.Collections;

public class CreateAttackEffect : MonoBehaviour {

    private Fighter fighter;

	// Use this for initialization
	void Start () {
        fighter = GetComponentInParent<Fighter>();
	}
	
	public void createAttackEffect()
    {
        fighter.CreateAttackEffect();
    }
}
