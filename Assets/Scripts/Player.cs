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

	protected virtual void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			HP -= other.gameObject.GetComponent<Enemy>().contactDamage;
		}
	}
}
