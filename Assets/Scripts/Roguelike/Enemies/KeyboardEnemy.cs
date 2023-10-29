using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEnemy : Enemy
{
	/*
	[SerializeField] private Animator animator;
	[SerializeField] private float normalSpeed;
	[SerializeField] private float dashSpeed;
	protected override IEnumerator AI()
	{
		yield return new WaitForSeconds(2f);
		StopCoroutine(MeleeAttack());
		while (true)
		{
			animator.SetTrigger("Walk");
			for (float i = 0; i < Random.Range(2f, 3f); i += Time.deltaTime)
			{
				Move(facingDir * Time.deltaTime);
				RotateAngle(2f);
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(0.1f);
			speed = 0;
			yield return new WaitForSeconds(1f);
			speed = dashSpeed;
			animator.SetTrigger("Dash");
			for (float i = 0; i < 2f; i += Time.deltaTime)
			{
				Move(facingDir);
				yield return null;
			}
			speed = normalSpeed;
			yield return new WaitForSeconds(0.2f);
		}
	}
    
	IEnumerator MeleeAttack()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(0f, 0.5f));
			if (GameManager.Instance.DistanceToPlayer(transform.position) < 1.2f)
			{
				weapon.Fire();
			}
		}
	}
	*/
}