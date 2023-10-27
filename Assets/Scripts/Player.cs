using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	[SerializeField] private Rigidbody rb;
	private bool isControlled;
	public SpriteAnimator playerAnimator;

	public override void Move(Vector2 vector2)
	{
		rb.MovePosition(transform.position + new Vector3(vector2.x, 0f, vector2.y));
	}

	public override void Rotate(Vector2 vector2)
	{
		//rb.MoveRotation(Quaternion.Euler(vector2));

	}

	public bool IsControlled()
	{
		return isControlled;
	}
}
