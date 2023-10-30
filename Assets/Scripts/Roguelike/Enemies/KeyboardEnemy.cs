using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEnemy : Enemy
{
	[SerializeField] private float maxSpeed = 2f;

	[SerializeField] private float attackSpeed = 0.5f;

	float attackCooldown = 0f;

	void FixedUpdate()
	{
		WaitStateHandler();

		Vector3 movementDir = player.transform.position - gameObject.transform.position;
		facingDir = Vector3.Normalize(player.transform.position - gameObject.transform.position);

		attackCooldown -= Time.deltaTime;

		if (Vector3.Distance(player.transform.position, transform.position) < 1.2f) {
			movementDir = -movementDir;

			if (attackCooldown <= 0f) {
				Attack();
				attackCooldown = attackSpeed;
			}
		}

		Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
		Vector3 resultantForce = Vector3.zero;

		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				Vector3 dir = transform.position - colliders[i].transform.position;
				resultantForce += dir.normalized;
			}
		}

		movementDir += resultantForce;

		rb.AddForce(movementDir * speed, ForceMode.Impulse);
		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1f);

		Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
		Vector3 resultantForce = Vector3.zero;

		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				Vector3 dir = transform.position - colliders[i].transform.position;
				resultantForce += dir.normalized;
			}
		}

		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, resultantForce);
		Vector3 movementDir = new Vector3(facingDir.x, 0, facingDir.y);
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, movementDir);
	}

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