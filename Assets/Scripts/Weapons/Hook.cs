using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Weapon
{
	public GameObject HookTip;
	public Transform PlayerPivot;
	public float spinSpeed;
	public float pullStrength;
	public override void Fire()
	{
		//here spawn hook and make it travel
		if (combo == 0)
		{
			base.Fire();
			if (needsReload) return;
			HookTip = SpawnProj(combo, spawner.facingDir, false);
		}
		/*
		else if (combo == 1) //lodge hook in the ground
		{
			//HookTip.lifetime = 10000;
			HookTip.GetComponent<Projectile>().rb.velocity = Vector3.zero;
			HookTip.GetComponent<Projectile>().damage = HookTip.GetComponent<Projectile>().damage * 0.2f;
			//here change sprite:
		}
		else if (combo == 2) //lunch towards hook
		{
			spawner.rb.AddForce(Vector3.Normalize(HookTip.transform.position - spawner.transform.position) * pullStrength * Vector3.Distance(spawner.transform.position, HookTip.transform.position), ForceMode.Impulse);
			Destroy(HookTip.gameObject);
		}
		*/

		combo += 1;
		if (combo >= 3)
		{
			combo = 0;
		}
	}

	public override void Charge()
	{
		base.Charge();
		//here make hook spin
		if (combo == 1)
		{
			if (PlayerPivot == null)
			{
				PlayerPivot = Instantiate(new GameObject(), spawner.transform).transform;
				HookTip.GetComponent<Projectile>().rb.isKinematic = true;
				HookTip.transform.SetParent(PlayerPivot.transform); //PlayerPivot.gameObject.AddComponent<FakeChildObject>().pivot = spawner.transform;
			}
			//spin
			PlayerPivot.transform.RotateAroundLocal(new Vector3(0, spinSpeed, 0), spinSpeed);

		}
	}

	public override void ReleaseCharge()
	{
		base.ReleaseCharge();
		if (combo == 1)
		{
			Destroy(HookTip.gameObject);
			Destroy(PlayerPivot.gameObject);
			combo = 0;
		}
	}

	public override void OnTargetHit(Entity target, Projectile source, out bool hit)
	{
		base.OnTargetHit(target, source, out hit);
		if (target == spawner)
		{
			//delete hookTip
			Destroy(HookTip);
		}
	}
}
