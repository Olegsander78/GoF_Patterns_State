using UnityEngine;

namespace Task2
{
    public class WorkerStateResolver : MonoBehaviour
    {
        [SerializeField] private WorkerConfig _config;
        [SerializeField] private WorkerView _view;

        [SerializeField] private WorkerStateMachine _stateMachine;
        public WorkerConfig Config => _config;
        public WorkerView View => _view;

        private void Awake()
        {
            _view.Initialize();
            _stateMachine.SwitchState(_stateMachine.CurrentStateType);
        }
    }
}

