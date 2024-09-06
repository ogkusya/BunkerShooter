using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; } //Current state

    public StateMachine(State defaultState) //Construct
    {
        SetState(defaultState); //We set the first state for our machine
    }

    public void OnUpdate() //Update
    {
    var deltaTime = Time.deltaTime;
        var newIndex = IsTransitionsCondition(); //Check all transitions for current state 
        
            if (newIndex != -1) //If a transition is found with a fullfilled condition, then we change the state to the one indicated in the transition
            {
                SetState(CurrentState.Transitions[newIndex].StateTo); //Set next state
            }
            else //If none of the conditions are met, then we call Update() method on the state
            {
                CurrentState.OnUpdate(deltaTime);
            }
        
    }

    public void OnFixedUpdate()
    {
        var fixedDeltaTime = Time.deltaTime;
        CurrentState.OnFixedUpdate(fixedDeltaTime);
    }

    private int IsTransitionsCondition() //We check all transitions and call their tick method
    {
        var deltaTime = Time.deltaTime;
        var currentTransitions = CurrentState.Transitions;
        for (var i = 0; i < currentTransitions.Count; i++)
        {
            var condition = currentTransitions[i].Condition;
            condition.OnTick(deltaTime);
            if (condition.IsConditionSuccessed())
            {
                return i;
            }
        }

        return -1;
    }

    public void SetState(State state)//We leave the previous state and move into a new one
    {
        CurrentState?.OnStateExited();
        CurrentState?.DeInitializeTransitions();

        CurrentState = state;
        CurrentState.OnStateEntered();
        CurrentState.InitializeTransitions();
    }
}
