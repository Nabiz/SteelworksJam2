using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCameraWithMouse : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 initialPosition;
    
    private void Start()
    {
        initialPosition = cameraTransform.position;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 vector2 = (context.ReadValue<Vector2>() - new Vector2(1920f / 2f, 1080f / 2f)) / 1000f;
        cameraTransform.position = initialPosition + new Vector3(vector2.x, vector2.y, 0);
    }
}
