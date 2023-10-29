using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : Entity
{
	[SerializeField] protected float speed;
	[SerializeField] SpriteAnimator animator;
	protected Player player;
	public int state;
	public float waitTimer;
	public int nextState;
	public int requiredState; //if -1 no state required
	private float currentWaitTimer;
	private bool isCharging;
	//
	
	private void Awake()
	{
		//StartCoroutine(AI());
		state = 0;
		nextState = 0;
		waitTimer = 0;
		currentWaitTimer = 0;
		requiredState = -1;
		isCharging = false;
	}

	private void Start()
	{
		player = GameManager.Instance.GetPlayer();
		animator = gameObject.GetComponentInChildren<SpriteAnimator>();
		weapon = gameObject.GetComponentInChildren<Weapon>();
	}

	protected void WaitStateHandler()
	{
		currentWaitTimer += Time.deltaTime;
		if (currentWaitTimer > waitTimer)
		{
			state = nextState;
			currentWaitTimer = 0;
			requiredState = -1;
		}
	}

	public void Update()
	{
		animator.SetDirectionAll(facingDir);
	}

	//schould be override but this is Unity update, so I do not want to interfiere
	public void FixedUpdate()
	{
		WaitStateHandler();
	}

	//delete later
	public override void Move(Vector2 move)
	{
		rb.AddForce(new Vector3(move.x, 0, move.y) * speed, ForceMode.Force);
	}

	/*
	public void RotateAngle(float angle)
	{
		facingDir = RotateVector(facingDir, angle);
	}
	*/
	
	Vector3 RotateVector(Vector3 vector, float angleInDegrees)
	{
		float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
		float x = vector.x * Mathf.Cos(angleInRadians) - vector.y * Mathf.Sin(angleInRadians);
		float y = vector.x * Mathf.Sin(angleInRadians) + vector.y * Mathf.Cos(angleInRadians);
		return new Vector3(x, y, vector.z);
	}

	public virtual void Attack()
	{
		if (weapon)
		{
			if (isCharging)
			{
				isCharging = false;
				weapon.ReleaseCharge();
			}
			else
			{
				weapon.Fire();
			}
		}

	}

	public virtual void ChargeAttack()
	{
		isCharging = true;
		weapon.Charge();
	}

	public override void Die()
	{
		base.Die();
		RoomGenerator.Instance.currentRoom.EnemyDied(this);
	}
}
