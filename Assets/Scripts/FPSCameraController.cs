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
        // �¿�
        // transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
        // ���Ʒ�
        // cameraRoot.Rotate(Vector3.right, mouseSensitivity * -inputDir.y * Time.deltaTime);

        xRotation -= inputDir.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, 80f, 80f);
        // y �������� ������ ��� : �¿�
        transform.Rotate(Vector3.up, mouseSensitivity * inputDir.y * Time.deltaTime);

        // x �������� ������ ��� : ���Ʒ�
        cameraRoot.localRotation = Quaternion.Euler(0, xRotation, 0);

	}
	private void OnLook(InputValue value)
    {
        // Debug.Log(value.Get<Vector2>());
        inputDir = value.Get<Vector2>();
    }
}
