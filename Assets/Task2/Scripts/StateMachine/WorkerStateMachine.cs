using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task2
{
    public class WorkerStateMachine : MonoBehaviour, IStateSwitcher
    {
        [SerializeField, Space] private StateType _currentStateType;

        [SerializeField, Space] private List<StateHolder> _states;    
        public StateType CurrentStateType
        {
            get { return _currentStateType; }
        }  
        
        private State _currentState;

        public void SwitchState(StateType stateType)
        {
            var currentState = _states.FirstOrDefault(state => state.type == stateType).state;

            if (_currentState != null)
                _currentState.Exit();

            _currentStateType = stateType;
            _currentState = currentState;
            _currentState.Enter();
        }

        [Serializable]
        private struct StateHolder
        {
            [SerializeField]
            public StateType type;

            [SerializeField]
            public State state;
        }
    }
}