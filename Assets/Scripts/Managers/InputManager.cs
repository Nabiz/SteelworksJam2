using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 speed;
    private Vector2 rotation;

    private void FixedUpdate()
    {
        if (GameManager.Instance.GetPlayer().IsControlled())
		{
            Vector3 PlayerScreenPos = GameManager.Instance.GetCamera().WorldToScreenPoint(GameManager.Instance.GetPlayer().transform.position);
            Vector2 screenRot = new Vector2(rotation.x - PlayerScreenPos.x, rotation.y - PlayerScreenPos.y);
            screenRot = new Vector2(screenRot.x / GameManager.Instance.GetCamera().pixelWidth, screenRot.y / GameManager.Instance.GetCamera().pixelHeight);
            screenRot.Normalize();
            GameManager.Instance.GetPlayer().facingDir = screenRot;
            GameManager.Instance.GetPlayer().Move(speed);
            GameManager.Instance.GetPlayer().Rotate(screenRot);
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

        GameManager.Instance.GetPlayer().Fire();
    }

    public void Takeover(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (GameManager.Instance.gameState == Enums.GameState.realWorld)
        {
            ((PlayerRealWorld)GameManager.Instance.GetPlayer()).Takeover();
        }
    }
}
