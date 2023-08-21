using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private SpeedRunningStateConfig _speedRunningStateConfig;
    [SerializeField, Space] private AirborneStateConfig _airborneStateConfig;

    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public SpeedRunningStateConfig SpeedRunningStateConfig => _speedRunningStateConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
}
