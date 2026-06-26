using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleInput : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;
	public Vector2 look;
	public bool jump;
	public bool pause;


	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}
	public void StripInput()
	{
		jump = false;
		move = Vector2.zero;
		look = Vector2.zero;

	}
	public void OnLook(InputValue value)
	{
		LookInput(value.Get<Vector2>());
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}

	public void OnPause(InputValue value)
	{
		PauseInput(value.isPressed);
	}

	//actions
	public void MoveInput(Vector2 newMoveDirection){move = newMoveDirection;}
	public void LookInput(Vector2 newLookDirection){look = newLookDirection;}
	public void JumpInput(bool newJumpState){jump = newJumpState;}
	public void PauseInput(bool newSprintState){pause = newSprintState;}
	public void SetCursorMode(bool _cursorMode)
	{
		Cursor.lockState = _cursorMode ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = _cursorMode;
	}
}
