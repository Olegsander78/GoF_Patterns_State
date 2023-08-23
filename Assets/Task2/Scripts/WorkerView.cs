using UnityEngine;

namespace Task2
{
    [RequireComponent(typeof(Animator))]
    public class WorkerView : MonoBehaviour
    {
        private int RestHash = Animator.StringToHash("Rest");
        private int GoToHash = Animator.StringToHash("GoTo");
        private int WorkHash = Animator.StringToHash("Work");

        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartResting()
        {
            _animator.StopPlayback();
            _animator.CrossFade(RestHash, 0.15f);
        }

        public void StartGoing()
        {
            _animator.StopPlayback();
            _animator.CrossFade(GoToHash, 0.15f);
        }

        public void StartWorking()
        {
            _animator.StopPlayback();
            _animator.CrossFade(WorkHash, 0.15f);
        }
        public void StartSmoking()
        {
            _animator.StopPlayback();
            _animator.CrossFade(WorkHash, 0.15f);
        }
        public void StartHavingLunch()
        {
            _animator.StopPlayback();
            _animator.CrossFade(WorkHash, 0.15f);
        }
        public void StopDoAnything() => _animator.StopPlayback();
    }
}
