using UnityEngine;
using System.Collections;

/*Script que lleva el Panel al último para que se visualice el primero.
*/
public class BringToFront : MonoBehaviour {

	void onEnable()
    {
        transform.SetAsLastSibling();
    }
}
