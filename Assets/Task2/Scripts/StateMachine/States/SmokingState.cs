using System.Collections;
using UnityEngine;

namespace Task2
{
    public class SmokingState : StateCoroutine
    {
        [SerializeField] private WorkerStateMachine _stateSwitcher;
        [SerializeField] private WorkerStateResolver _workerStateResolver;
        [SerializeField] private StateTypes _nextStateType;
        protected WorkerView View => _workerStateResolver.View;

        private Coroutine _coroutine;

        public override void Enter()
        {
            base.Enter();

            Debug.Log(GetType());

            if (_coroutine == null)
            {
                Debug.Log($"Start coroutine Smoke");
                _coroutine = StartCoroutine(Do());
            }

            View.StartSmoking();
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
            yield return new WaitForSecondsRealtime(_workerStateResolver.Config.SmokingStateConfig.SmokingTime);

            Debug.Log($"End coroutine Smoke");
            _stateSwitcher.SwitchState(_nextStateType);
        }
    }
}