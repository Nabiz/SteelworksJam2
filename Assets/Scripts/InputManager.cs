using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] Player player;
    private Vector2 speed;
    private Vector2 rotation;
    
    private void Update()
    {
        if (player.IsControlled())
		{
            player.Move(speed);
            player.Rotate(rotation);
        }

    }

    public void Move (InputAction.CallbackContext context)
    {
        if (context.canceled)
            speed = Vector2.zero;
        
        if (!context.performed)
            return;
        
        speed = context.ReadValue<Vector2>();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        rotation = context.ReadValue<Vector2>();
        Debug.Log(rotation);
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        player.Fire();
    }
}
