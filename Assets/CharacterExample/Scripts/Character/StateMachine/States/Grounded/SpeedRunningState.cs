public class SpeedRunningState : GroundedState
{
    private SpeedRunningStateConfig _config;
    public SpeedRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.SpeedRunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.SpeedRunningSpeed;

        View.StartSpeedRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopSpeedRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizonatalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForWalking())
            StateSwitcher.SwitchState<WalkingState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForRunning())
            StateSwitcher.SwitchState<RunningState>();
    }
}
   
