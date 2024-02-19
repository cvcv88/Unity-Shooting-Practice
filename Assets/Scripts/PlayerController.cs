using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Component")]
	[SerializeField] CharacterController controller;

	[Header("Spec")]
	[SerializeField] float moveSpeed;
	[SerializeField] float jumpSpeed;

	private Vector3 moveDir;
	private float ySpeed; // 점프와 중력 주기 위해 ySpeed 만들기

	[SerializeField] LayerMask groundChecker;
	[SerializeField] bool isGround;

	private void OnTriggerEnter(Collider collision)
	{
		if (groundChecker.Contain(collision.gameObject.layer))
		{
			isGround = true;
		}
	}
	private void OnTriggerExit(Collider collision)
	{
		if (groundChecker.Contain(collision.gameObject.layer))
		{
			isGround = false;
		}
	}

	private void Update()
	{
		Move();
		Jump();
	}

	private void Move()
	{
		controller.Move(moveSpeed * moveDir * Time.deltaTime);
	}
	private void OnMove(InputValue value)
	{
		Vector2 inputDir = value.Get<Vector2>();
		moveDir.x = inputDir.x; // 키보드 x 좌우
		moveDir.z = inputDir.y; // 키보드 y 앞뒤 (z, y는 위아래)
	}
	private void Jump() // jump는 단순 스페이스바라서 moveDir 활용 안함
	{
		ySpeed += Physics.gravity.y * Time.deltaTime;

		Debug.Log(isGround);
		if (isGround && ySpeed < 0)
		{
			ySpeed = 0;
		}
		controller.Move(ySpeed * Vector3.up * Time.deltaTime);
	}
	private void OnJump(InputValue value)
	{
		if (isGround)
		{
			ySpeed = jumpSpeed;
		}
	}
}
