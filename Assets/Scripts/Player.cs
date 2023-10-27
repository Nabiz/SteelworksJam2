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

	public override void Rotate(Vector2 mousePos)
	{
		//get mouse pos vs player pos:
		Vector3 PlayerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
		Vector2 rot = new Vector2(mousePos.x - PlayerScreenPos.x, mousePos.y - PlayerScreenPos.y);
		rot = new Vector2(rot.x / Camera.main.pixelWidth, rot.y / Camera.main.pixelHeight);
		rot.Normalize();
		Debug.Log(rot);

		//rb.MoveRotation(Quaternion.Euler(vector2));
		if (Mathf.Abs(rot.x) > Mathf.Abs(rot.y))
		{
			if (rot.x > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.right);
				Debug.Log("right");
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.left);
				Debug.Log("left");
			}
		}
		else
		{
			if (rot.y > 0)
			{
				playerAnimator.SetDirectionAll(Enums.Direction.up);
				Debug.Log("up");
			}
			else
			{
				playerAnimator.SetDirectionAll(Enums.Direction.down);
				Debug.Log("down");
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
