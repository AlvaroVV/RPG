using UnityEngine;
using System.Collections;

public class CreateAttackEffect : MonoBehaviour {

	
	public void createAttackEffect()
    {
        FighterActionManager.Instance.CreateAttackEffect();
    }
}
