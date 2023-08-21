public class FallingState : AirborneState
{
    private GroundChecker _groundChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling(); 
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizonatalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForWalking())
                StateSwitcher.SwitchState<WalkingState>();
            else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForRunning())
                StateSwitcher.SwitchState<RunningState>();
            else if (!IsHorizonatalInputZero() && IsHorizontalInputSituableForSpeedRunning())
                StateSwitcher.SwitchState<SpeedRunningState>();
        }
    }
}
