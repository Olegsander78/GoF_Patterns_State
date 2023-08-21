public class WalkingState : GroundedState
{
    private WalkingStateConfig _config;
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.WalkingSpeed;

        View.StartWalking();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizonatalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForRunning())
            StateSwitcher.SwitchState<RunningState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForSpeedRunning())
            StateSwitcher.SwitchState<SpeedRunningState>();
    }
}
