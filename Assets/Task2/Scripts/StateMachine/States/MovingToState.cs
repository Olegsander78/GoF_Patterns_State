using System;
using System.Collections;
using UnityEngine;

namespace Task2
{
    public class MovingToState : StateCoroutine
    {       
        [SerializeField] private WorkerStateMachine _stateSwitcher;
        [SerializeField] private WorkerStateResolver _workerDispatcher;
        [SerializeField] private Place _placeTarget;

        protected WorkerView View => _workerDispatcher.View;

        private Vector3 _targetPosition;

        private Coroutine _coroutine;

        public override void Enter()
        {
            _targetPosition = _placeTarget.transform.position;

            base.Enter();

            Debug.Log(GetType());

            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Do());
            }

            View.StartGoing();
        }

        public override void Exit()
        {
            base.Exit();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            View.StopDoAnything();
        }

        protected override IEnumerator Do()
        {
            var delay = new WaitForFixedUpdate();
            while (true)
            {
                yield return delay;
                Move();
            }
        }

        private void Move()
        {
            var currentPosition = _workerDispatcher.transform.position;
            var maxDistanceDelta = _workerDispatcher.Config.GoingStateConfig.GoingSpeed * Time.deltaTime;
            var newPosition = Vector3.MoveTowards(currentPosition, _targetPosition, maxDistanceDelta);
            _workerDispatcher.transform.position = newPosition;

            RotateTowards();
            SwitchToNextState();           
        }

        private void RotateTowards()
        {
            var currentRotation = _workerDispatcher.transform.rotation;
            var direction = (_targetPosition - _workerDispatcher.transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            var newRotation = Quaternion.Slerp(currentRotation, targetRotation, 3f * Time.deltaTime);
            _workerDispatcher.transform.rotation = newRotation;
        }

        private void SwitchToNextState()
        {
            if (_targetPosition == _workerDispatcher.transform.position && _placeTarget.PlaceType == PlaceTypes.WORK_PLACE)
                _stateSwitcher.SwitchState(StateTypes.WORK);

            if (_targetPosition == _workerDispatcher.transform.position && _placeTarget.PlaceType == PlaceTypes.REST_PLACE)
                _stateSwitcher.SwitchState(StateTypes.REST);

            if (_targetPosition == _workerDispatcher.transform.position && _placeTarget.PlaceType == PlaceTypes.SMOKING_PLACE)
                _stateSwitcher.SwitchState(StateTypes.SMOKE);

            if (_targetPosition == _workerDispatcher.transform.position && _placeTarget.PlaceType == PlaceTypes.LUNCH_PLACE)
                _stateSwitcher.SwitchState(StateTypes.LUNCH);
        }
    }
}