using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	private bool isControlled;
	public SpriteAnimator playerAnimator;

	private void Start()
	{
		isControlled = true;
	}

	public override void Move(Vector2 move)
	{
		rb.MovePosition(transform.position + new Vector3(move.x, 0f, move.y));
	}

	public override void Rotate(Vector2 rot)
	{
		//get mouse pos vs player pos:
		Debug.Log(rot);
		//rb.MoveRotation(Quaternion.Euler(vector2));
		if (rot.x > rot.y)
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
	}

	public bool IsControlled()
	{
		return isControlled;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			HP -= other.gameObject.GetComponent<Enemy>().contactDamage;
		}
	}
}
