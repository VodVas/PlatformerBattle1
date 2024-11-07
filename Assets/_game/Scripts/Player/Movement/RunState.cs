using UnityEngine;

public class RunState : PlayerState
{
    private const string _horizontal = "Horizontal";
    private const string _isRunning = "IsRunning";
    private const string _jump = "Jump";
    private const string _run = "Run";

    private Move _move;

    public RunState(PlayerStateMachine playerController, Move move) : base(playerController) 
    {
        _move = move;
    }

    public override void Enter()
    {
        _player.Animator.SetBool(_isRunning, true);
    }

    public override void Update()
    {
        _move.DoMove(_player.RunSpeed);

        if (Input.GetAxisRaw(_horizontal) == 0)
        {
            _player.ChangeState(_player.IdleState);
        }
        else if (Input.GetButtonDown(_jump))
        {
            _player.ChangeState(_player.JumpState);
        }
        else if (!Input.GetButton(_run))
        {
            _player.ChangeState(_player.WalkState);
        }
    }

    public override void Exit()
    {
        _player.Animator.SetBool(_isRunning, false);
    }
}