using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] float mouseSensitivity;

    private Vector2 inputDir;

	private void Update()
	{
        // ÁÂ¿ì
        transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
        
        // À§¾Æ·¡
        cameraRoot.Rotate(Vector3.right, mouseSensitivity * -inputDir.y * Time.deltaTime);

	}
	private void OnLook(InputValue value)
    {
        // ebug.Log(value.Get<Vector2>());
        inputDir = value.Get<Vector2>();
    }
}
