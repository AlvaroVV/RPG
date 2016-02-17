using UnityEngine;
using System.Collections;

public interface IState {

    //Inicializaciones del estado
    void StartState();

    //Efecto del estado, tendrá corrutinas para que sea el usuario quien vaya pasando.
    void UpdateState();

    //Cada estado sabe a que estado ir
    void changeState();

    
}
