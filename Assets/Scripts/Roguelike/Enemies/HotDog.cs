using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotDog : Enemy
{
	[SerializeField] private Animator animator;
	[SerializeField] private float minJumpCooldown;
	[SerializeField] private float maxJumpCooldown;
	[SerializeField] private float minShootCooldown;
	[SerializeField] private float maxShootCooldown;
	[SerializeField] private float jumpForce;
	[SerializeField] private float jumpForceUp;
	[SerializeField] private float scatterDistance;
	[SerializeField] private float jumpHeight = 2f;

	private Vector3 jumpStartPos, jumpEndPos, jumpAnchor;

	float progress;

	bool isJumping = false;

	void Update() {
		if (!isJumping) return;

		progress += Time.deltaTime;

		transform.position = Lerp(progress);

		if (progress >= 1f)
		{
			progress = 0;
			isJumping = false;
		}
	}
	
	protected override IEnumerator AI()
	{
		while (true)
		{
			yield return new WaitForSeconds(UnityEngine.Random.Range(minJumpCooldown, maxJumpCooldown));

			Debug.Log($"{GameManager.Instance.DistanceToPlayer(transform.position)} {scatterDistance}");
			
			if (GameManager.Instance.DistanceToPlayer(transform.position) > scatterDistance) {
				Debug.Log("Jump Towards");
				Jump();
			}
			else
			{
				Debug.Log("Jump Away");
				JumpBack();
			} 
			
			yield return new WaitForSeconds(UnityEngine.Random.Range(minShootCooldown, maxShootCooldown));
		}
	}

	void Jump()
	{
		jumpStartPos = transform.position;
		jumpEndPos = GameManager.Instance.GetPlayer().transform.position;
		jumpAnchor = Vector3.Lerp(jumpStartPos, jumpEndPos, 0.5f) + Vector3.forward * jumpHeight;

		jumpStartPos.y = jumpEndPos.y = jumpAnchor.y = 0f;
		isJumping = true;

		return;
		Vector3 direction = GameManager.Instance.GetPlayer().transform.position - transform.position;
		direction.Normalize();
		direction += Vector3.up * jumpForceUp;
		direction *= jumpForce;
		
		rb.AddForce(direction + new Vector3(Random.Range(0, .2f), Random.Range(0, .2f), Random.Range(0, .2f)), ForceMode.Impulse);
	}
	
	void JumpBack()
	{
		Vector3 center = RoomGenerator.Instance.currentRoom.transform.position;

		float xDimension = 19.20f;
		Vector2 xBounds = new Vector2(center.x - xDimension * 0.5f, center.x + xDimension * 0.5f);

		float zDimension = 10.80f;
		Vector2 zBounds = new Vector2(center.z - zDimension * 0.5f, center.z + zDimension * 0.5f);

		Vector3 randomPos = new Vector3(Random.Range(xBounds.x, xBounds.y), 0, Random.Range(zBounds.x, zBounds.y));

		jumpStartPos = transform.position;
		jumpEndPos = randomPos;
		jumpAnchor = Vector3.Lerp(jumpStartPos, jumpEndPos, 0.5f) + Vector3.forward * jumpHeight;

		jumpStartPos.y = jumpEndPos.y = jumpAnchor.y = 0f;
		isJumping = true;

		return;
		Vector3 direction = transform.position - GameManager.Instance.GetPlayer().transform.position;
		direction.Normalize();
		direction += Vector3.up * jumpForceUp;
		direction *= jumpForce;

		rb.AddForce(direction + new Vector3(Random.Range(0, .2f), Random.Range(0, .2f), Random.Range(0, .2f)), ForceMode.Impulse);
	}

	public Vector3 Lerp(float t) {
        Vector3 pointAB = Vector3.Lerp(jumpStartPos, jumpAnchor, t);
        Vector3 pointBC = Vector3.Lerp(jumpAnchor, jumpEndPos, t);
        return Vector3.Lerp(pointAB, pointBC, t);
    }

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
        Gizmos.DrawSphere(jumpStartPos, 0.1f);
        Gizmos.DrawSphere(jumpEndPos, 0.1f);

        for (float t = 0; t < 1.0f; t += 0.1f)
            Gizmos.DrawLine(Lerp(t), Lerp(t + 0.1f));

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(jumpAnchor, 0.1f);	
	}
}