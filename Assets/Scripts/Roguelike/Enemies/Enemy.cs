using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : Entity
{
	[SerializeField] protected float speed;
	
	private void Awake()
	{
		StartCoroutine(AI());
	}

	public override void Move(Vector2 move)
	{
		rb.AddForce(new Vector3(move.x, 0, move.y) * speed, ForceMode.Force);
	}

	public void RotateAngle(float angle)
	{
		facingDir = RotateVector(facingDir, angle);
	}

	protected abstract IEnumerator AI();
	
	Vector3 RotateVector(Vector3 vector, float angleInDegrees)
	{
		float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
		float x = vector.x * Mathf.Cos(angleInRadians) - vector.y * Mathf.Sin(angleInRadians);
		float y = vector.x * Mathf.Sin(angleInRadians) + vector.y * Mathf.Cos(angleInRadians);
		return new Vector3(x, y, vector.z);
	}

	public override void Die()
	{
		base.Die();
		RoomGenerator.Instance.currentRoom.EnemyDied(this);
	}
}
