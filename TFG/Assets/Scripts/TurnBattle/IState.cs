using UnityEngine;
using System.Collections;

public interface IState {

    //Efecto del estado, tendrá corrutinas para que sea el usuario quien vaya pasando.
    IEnumerator UpdateState();

    //Cada estado sabe a que estado ir
    void changeState();

    
}
