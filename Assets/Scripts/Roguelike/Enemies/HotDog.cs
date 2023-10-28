using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotDog : Enemy
{
	[SerializeField] private Animator animator;
	[SerializeField] private float minJumpCooldown;
	[SerializeField] private float maxJumpCooldown;
	[SerializeField] private float jumpForce;
	[SerializeField] private float jumpForceUp;
	[SerializeField] private float scatterDistance;

	protected override IEnumerator AI()
	{
		StartCoroutine(MeleeAttack());
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minJumpCooldown, maxJumpCooldown));
			if (GameManager.Instance.DistanceToPlayer(transform.position) > scatterDistance)
				Jump();
			else
				JumpBack();
			yield return new WaitForSeconds(Random.Range(1f, 4f));
		}
	}
	
	IEnumerator MeleeAttack()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(1f, 2f));
			if (GameManager.Instance.DistanceToPlayer(transform.position) < 2f)
			{
				facingDir = GameManager.Instance.GetPlayer().transform.position - transform.position;
				weapon.Fire();
			}
		}
	}

	void Jump()
	{
		Vector3 direction = GameManager.Instance.GetPlayer().transform.position - transform.position;
		direction.Normalize();
		direction += Vector3.up * jumpForceUp;
		direction *= jumpForce;
		
		rb.AddForce(direction + new Vector3(Random.Range(0, .2f), Random.Range(0, .2f), Random.Range(0, .2f)), ForceMode.Impulse);
	}
	
	void JumpBack()
	{
		Vector3 direction = transform.position - GameManager.Instance.GetPlayer().transform.position;
		direction.Normalize();
		direction += Vector3.up * jumpForceUp;
		direction *= jumpForce;

		rb.AddForce(direction + new Vector3(Random.Range(0, .2f), Random.Range(0, .2f), Random.Range(0, .2f)), ForceMode.Impulse);
	}
}