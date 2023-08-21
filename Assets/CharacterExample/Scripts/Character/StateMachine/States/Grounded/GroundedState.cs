using UnityEngine.InputSystem;

public class GroundedState : MovementState
{
    private GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
        Input.Movement.Walk.started += OnWalkKeyPressed;
        Input.Movement.Run.started += OnRunKeyPressed;
        Input.Movement.SpeedRun.started += OnSpeedRunKeyPressed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
        Input.Movement.Walk.started -= OnWalkKeyPressed;
        Input.Movement.Run.started -= OnRunKeyPressed;
        Input.Movement.SpeedRun.started -= OnSpeedRunKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj)
        => StateSwitcher.SwitchState<JumpingState>();

    private void OnWalkKeyPressed(InputAction.CallbackContext context)
        => StateSwitcher.SwitchState<WalkingState>();

    private void OnRunKeyPressed(InputAction.CallbackContext context)
        => StateSwitcher.SwitchState<RunningState>();

    private void OnSpeedRunKeyPressed(InputAction.CallbackContext context)
        => StateSwitcher.SwitchState<SpeedRunningState>();
}

