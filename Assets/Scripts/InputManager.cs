using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] TwinSticksController twinSticksController;
    private Vector2 speed;
    private Vector2 rotation;
    
    private void Update()
    {
        twinSticksController.Move(speed);
        twinSticksController.Rotate(rotation);
    }

    public void Move (InputAction.CallbackContext context) {
        if (!context.performed)
            return;
        
        speed = context.ReadValue<Vector2>();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>();
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        twinSticksController.Fire();
    }
}
