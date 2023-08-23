using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Task2
{
    public class WorkerStateMachine : MonoBehaviour, IStateSwitcher
    {
        [SerializeField, Space] private StateTypes _currentStateType;
        [SerializeField, Space] private List<StateHolder> _states;    
        public StateTypes CurrentStateType
        {
            get { return _currentStateType; }
        }  
        
        private List<StateHolder> _processedStates = new();
        private State _currentState;
        
        public void SwitchState(StateTypes stateType)
        {
            var currentStateHolder = _states.Find(stateHolder => stateHolder.type == stateType);            

            if (currentStateHolder.state != null)
            {
                _currentState?.Exit();

                _currentStateType = stateType;
                _currentState = currentStateHolder.state;
                _currentState.Enter();

                _processedStates.Add(currentStateHolder);
                _states.Remove(currentStateHolder);

                if (_states.Count == 0)
                {
                    _states.AddRange(_processedStates);
                    _processedStates.Clear();
                }
            }
        }

        [Serializable]
        private struct StateHolder
        {
            [SerializeField]
            public StateTypes type;

            [SerializeField]
            public State state;
        }
    }
}





//public void SwitchState(StateTypes stateType)
//{
//    var currentState = _states.FirstOrDefault(state => state.type == stateType).state;

//    if (_currentState != null)
//        _currentState.Exit();

//    _currentStateType = stateType;
//    _currentState = currentState;
//    _currentState.Enter();
//}