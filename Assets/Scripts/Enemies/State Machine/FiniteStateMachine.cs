using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter(); // Calls enter fuction in State.cs
    }

    public void ChangeState(State newState) // Function to change from one state to another
    {
        currentState.Exit();
        currentState = newState; // Make new state the current state
        currentState.Enter(); 
    }
}
