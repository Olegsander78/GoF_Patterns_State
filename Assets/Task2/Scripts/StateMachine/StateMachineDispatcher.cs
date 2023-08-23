//using System.Collections;
//using UnityEngine;

//namespace Task2
//{
//    public class StateMachineDispatcher : MonoBehaviour
//    {
//        [SerializeField] private WorkerStateMachine stateMachine;
                
//        //[SerializeField] private MoveInDirectionEngine moveEngine;

//        private void OnEnable()
//        {
//            //moveEngine.OnStartMove += OnMoveStarted;
//            //moveEngine.OnStopMove += OnMoveFinished;
//        }

//        private void OnDisable()
//        {
//            //moveEngine.OnStartMove -= OnMoveStarted;
//            //moveEngine.OnStopMove -= OnMoveFinished;
//        }

//        private void OnMoveStarted()
//        {
//            stateMachine.SwitchState(StateType.GOTO);
//        }

//        private void OnMoveFinished()
//        {
//            if (stateMachine.CurrentStateType == StateType.GOTO)
//            {
//                stateMachine.SwitchState(StateType.WORK);
//            }
//        }
//    }
//}