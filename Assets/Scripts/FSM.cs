using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FSM : MonoBehaviour
{
    public FSMStateType StartState = FSMStateType.Patrol;
    private IFSMState[] StatePool;
    private IFSMState CurrentState;
    //private  IFSMState EmptyState();
    private readonly IFSMState EmptyAction = new EmptyState(); //changed
    void Awake()
    {
        StatePool = GetComponents<IFSMState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = EmptyAction;
        TransitionToState(StartState);
    }

    private void TransitionToState(FSMStateType StateName)
    {
        CurrentState.OnExit();
        CurrentState = GetState(StateName);
        CurrentState.OnEnter();
        Debug.Log("Transitioned to " + CurrentState.StateName);
    }
    IFSMState GetState(FSMStateType StateName)
    {
        foreach (var state in StatePool)
        {
            if (state.StateName == StateName)
            {
                return state;
            }
        }
        return EmptyAction;
    }



    // Update is called once per frame
    void Update()
    {
        CurrentState.DoAction();
        FSMStateType TransitionState = CurrentState.ShouldTransitionToState();
        if (TransitionState != CurrentState.StateName)
        {
            TransitionToState(TransitionState);
        }
    }
}
