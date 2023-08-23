using UnityEngine;

namespace Task2
{
    [CreateAssetMenu(fileName = "WorkerConfig", menuName = "Configs/WorkerConfig")]
    public class WorkerConfig : ScriptableObject
    {
        [SerializeField] private RestingStateConfig _restingStateConfig;
        [SerializeField] private GoingStateConfig _goingStateConfig;
        [SerializeField] private WorkingStateConfig _workingStateConfig;
        [SerializeField] private SmokingStateConfig _smokingStateConfig;
        [SerializeField] private HavingLunchStateConfig _lunchStateConfig;

        public RestingStateConfig RestingStateConfig => _restingStateConfig;
        public GoingStateConfig GoingStateConfig => _goingStateConfig;
        public WorkingStateConfig WorkingStateConfig => _workingStateConfig;
        public SmokingStateConfig SmokingStateConfig => _smokingStateConfig;
        public HavingLunchStateConfig HavingLunchStateConfig => _lunchStateConfig; 
    }
}
