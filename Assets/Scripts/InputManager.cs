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
    
    private void FixedUpdate()
    {
        if (player.IsControlled())
		{
            Vector3 PlayerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
            Vector2 screenRot = new Vector2(rotation.x - PlayerScreenPos.x, rotation.y - PlayerScreenPos.y);
            screenRot = new Vector2(screenRot.x / Camera.main.pixelWidth, screenRot.y / Camera.main.pixelHeight);
            screenRot.Normalize();
            player.facingDir = screenRot;
            player.Move(speed);
            player.Rotate(screenRot);
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
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        player.Fire();
    }
}
