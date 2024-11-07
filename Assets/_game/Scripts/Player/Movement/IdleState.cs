using UnityEngine;

public class IdleState : PlayerState
{
    private const string _horizontal = "Horizontal";
    private const string _isIdle = "IsIdle";
    private const string _jump = "Jump";
    private const string _run = "Run";

    public IdleState(PlayerStateMachine playerController) : base(playerController) { }

    public override void Enter()
    {
        _player.Animator.SetBool(_isIdle, true);
    }

    public override void Update()
    {
        if (Input.GetAxisRaw(_horizontal) != 0)
        {
            _player.ChangeState(_player.WalkState);
        }
        else if (Input.GetButtonDown(_jump))
        {
            _player.ChangeState(_player.JumpState);
        }
        else if (Input.GetButton(_run))
        {
            _player.ChangeState(_player.RunState);
        }
    }

    public override void Exit()
    {
        _player.Animator.SetBool(_isIdle, false);
    }
}