using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 speed;
    private Vector2 rotation;
    private bool charged;

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
        if (context.performed)
        {
            Debug.Log("charging fire");
            charged = true;
            GameManager.Instance.GetPlayer().weapon.Charge();
        }
        else if (context.canceled && charged)
        {
            switch (GameManager.Instance.gameState)
            {
                case Enums.GameState.realWorld:
                    Debug.Log("can't release charge in real world");
                    break;
                case Enums.GameState.roguelike:
                    Debug.Log("release charge");
                    GameManager.Instance.GetPlayer().weapon.ReleaseCharge();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else if (context.canceled)
        {
            switch (GameManager.Instance.gameState)
            {
                case Enums.GameState.realWorld:
                    Debug.Log("real world takeover");
                    ((PlayerRealWorld)GameManager.Instance.GetPlayer()).Takeover();
                    break;
                case Enums.GameState.roguelike:
                    Debug.Log("fire");
                    GameManager.Instance.GetPlayer().Fire();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
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
