using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
   public enum States
    {
        Walk,
        PlayerFollow
    }

    public States _state = States.Walk;


    public void ChangeState(States state)
    {
        _state = state;
    }


}
