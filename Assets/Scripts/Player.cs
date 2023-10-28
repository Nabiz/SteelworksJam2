using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	public bool isControlled;
	public SpriteAnimator playerAnimator;
	public Transform playerChildControll;
	[SerializeField] private float ChildStretch;
	[SerializeField] private float speed;
	private Vector3 lastVelocity;
	private bool lastMoved;
	private float moveTimer;
	[SerializeField] private Vector3 velChange;

	private void Start()
	{
		isControlled = true;
	}

	public override void Move(Vector2 move)
	{
		//rb.MovePosition(transform.position + new Vector3(move.x, 0f, move.y));
		//rb.AddForce(new Vector3(move.x, 0f, move.y), ForceMode.Force);
		//rb.velocity = new Vector3(rb.velocity.x % (move.x + 1) + move.x, 0f, rb.velocity.x % (move.y + 1) + move.y);


		//playerChildControll.position = new Vector3(transform.position.x + move.x * ChildStretch, transform.position.y, transform.position.z + move.y * ChildStretch);

		//rb.MovePosition(new Vector3(transform.position.x + move.x * Time.deltaTime * speed, 0, transform.position.z + move.y * Time.deltaTime * speed));
		if (lastMoved)
		{
			Vector3 oldVel = rb.velocity;
			rb.AddForce(new Vector3(move.x, 0, move.y) * speed, ForceMode.Force);
			moveTimer += Time.deltaTime;
			Debug.Log(rb.velocity + " a " + oldVel);
			velChange += rb.velocity - oldVel;
			//rb.MovePosition(new Vector3(transform.position.x + move.x * Time.deltaTime * speed, 0, transform.position.z + move.y * Time.deltaTime * speed));
			if (move.magnitude == 0)
			{
				rb.AddForce(-velChange, ForceMode.Impulse);
				moveTimer = 0;
				velChange = new Vector3(0, 0, 0);
				lastMoved = false;
			}
		}
		else
		{
			if (move.magnitude != 0)
			{
				//lastVelocity = new Vector3(move.x, 0, move.y) * Time.deltaTime * speed;
				//rb.AddForce(lastVelocity, ForceMode.VelocityChange);
				lastMoved = true;
			}
		}
		lastVelocity = new Vector3(move.x, 0, move.y) * speed;

	}

	public override void Rotate(Vector2 rot)
	{
		//get mouse pos vs player pos:
		

		//rb.MoveRotation(Quaternion.Euler(vector2));
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
	}

	public bool IsControlled()
	{
		return isControlled;
	}

	public void Fire()
	{
		weapon.Fire();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			HP -= other.gameObject.GetComponent<Enemy>().contactDamage;
		}
	}
}
