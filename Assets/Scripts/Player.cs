using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	public bool isControlled;
	public SpriteAnimator playerAnimator;
	protected float currentSpeed;
	[SerializeField] protected float normalSpeed;
	[SerializeField] protected float takeoverSpeed;

	public GameObject[] weaponPrefab = new GameObject[3]; 

	public virtual void Start()
	{
		isControlled = true;
		currentSpeed = normalSpeed;
	}

	public override void Move(Vector2 move)
	{
		rb.AddForce(new Vector3(move.x, 0, move.y) * currentSpeed, ForceMode.Force);


		if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
		{
			if (move.x > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.right);
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.left);
			}
		}
		else
		{
			if (move.y > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.up);
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.down);
			}
		}
	}

	public override void Rotate(Vector2 rot)
	{
		/*
		if (Mathf.Abs(rot.x) > Mathf.Abs(rot.y))
		{
			if (rot.x > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.right);
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.left);
			}
		}
		else
		{
			if (rot.y > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.up);
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.down);
			}
		}
		*/
	}

	public bool IsControlled()
	{
		return isControlled;
	}

	public void Fire()
	{
		weapon.Fire();
	}

	public void EquipWeapon1()
	{
		weaponPrefab[0].SetActive(true);
		weaponPrefab[1].SetActive(false);
		weaponPrefab[2].SetActive(false);
		weapon = weaponPrefab[0].GetComponent<Weapon>();
	}
	
	public void EquipWeapon2()
	{
		weaponPrefab[0].SetActive(false);
		weaponPrefab[1].SetActive(true);
		weaponPrefab[2].SetActive(false);
		weapon = weaponPrefab[1].GetComponent<Weapon>();
	}
	
	public void EquipWeapon3()
	{
		weaponPrefab[0].SetActive(false);
		weaponPrefab[1].SetActive(false);
		weaponPrefab[2].SetActive(true);
		weapon = weaponPrefab[2].GetComponent<Weapon>();
	}
}
