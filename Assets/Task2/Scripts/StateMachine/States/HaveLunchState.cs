using System.Collections;
using UnityEngine;

namespace Task2
{
    public class HaveLunchState : StateCoroutine
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
                Debug.Log($"Start coroutine HaveLunch");
                _coroutine = StartCoroutine(Do());
            }

            View.StartHavingLunch();
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
            yield return new WaitForSecondsRealtime(_workerStateResolver.Config.HavingLunchStateConfig.HavingLunchTime);

            Debug.Log($"End coroutine Havelunch");
            _stateSwitcher.SwitchState(_nextStateType);
        }
    }
}