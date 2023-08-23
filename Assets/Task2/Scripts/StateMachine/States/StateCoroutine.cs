using System.Collections;
using UnityEngine;

namespace Task2
{
    public abstract class StateCoroutine : State
    {
        private Coroutine _coroutine;

        public override void Enter()
        {
            base.Enter();

            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Do());
            }
        }

        public override void Exit()
        {
            base.Exit();

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        protected abstract IEnumerator Do();
    }
}