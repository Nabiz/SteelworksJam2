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

        if (charged)
		{
            GameManager.Instance.GetPlayer().weapon.Charge();
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
        if (GameManager.Instance.gameState == Enums.GameState.realWorld)
        {
            return;
        }
        
        else
        if (context.performed && GameManager.Instance.gameState == Enums.GameState.roguelike)
        {
            charged = true;
            //GameManager.Instance.GetPlayer().weapon.Charge();
        }
        else if (context.canceled && charged)
        {
            GameManager.Instance.GetPlayer().weapon.ReleaseCharge();
            charged = false;
        }
        else if (context.canceled)
        {
            GameManager.Instance.GetPlayer().Fire();
        }
    }

    public void Takeover(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == Enums.GameState.roguelike)
        {
            return;
        }
        
        if (!context.performed)
        {
            return;
        }
        ((PlayerRealWorld)GameManager.Instance.GetPlayer()).Takeover();
    }

    public void RightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (GameManager.Instance.gameState)
            {
                case Enums.GameState.realWorld:
                    ((PlayerRealWorld)GameManager.Instance.GetPlayer()).ReleaseNPC();
                    break;
                case Enums.GameState.roguelike:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void ChooseWeapon1(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        GameManager.Instance.GetPlayer().EquipWeapon1();
    }
    
    public void ChooseWeapon2(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        GameManager.Instance.GetPlayer().EquipWeapon2();
    }
    
    public void ChooseWeapon3(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        GameManager.Instance.GetPlayer().EquipWeapon3();
    }
}
