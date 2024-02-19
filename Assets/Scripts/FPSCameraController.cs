using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] float mouseSensitivity;

    private Vector2 inputDir;
    private float xRotation;

	private void OnEnable()
	{
        Cursor.lockState = CursorLockMode.Locked;
	}
	private void OnDisable()
	{
        Cursor.lockState = CursorLockMode.None;
	}

	private void Update()
	{
        // 좌우
        // transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
        // 위아래
        // cameraRoot.Rotate(Vector3.right, mouseSensitivity * -inputDir.y * Time.deltaTime);

        xRotation -= inputDir.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, 80f, 80f);
        // y 기준으로 돌리는 경우 : 좌우
        transform.Rotate(Vector3.up, mouseSensitivity * inputDir.y * Time.deltaTime);

        // x 기준으로 돌리는 경우 : 위아래
        cameraRoot.localRotation = Quaternion.Euler(0, xRotation, 0);

	}
	private void OnLook(InputValue value)
    {
        // Debug.Log(value.Get<Vector2>());
        inputDir = value.Get<Vector2>();
    }
}
