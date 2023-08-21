public class RunningState : GroundedState
{
    private RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.RunningSpeed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();
               
        if (IsHorizonatalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForWalking())
            StateSwitcher.SwitchState<WalkingState>();
        else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForSpeedRunning())
            StateSwitcher.SwitchState<SpeedRunningState>();
    }
}
