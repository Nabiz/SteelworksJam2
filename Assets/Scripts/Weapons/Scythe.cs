using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
	public float knockback;
	public override void Fire()
	{
		base.Fire();
		if (needsReload) return;

		if (combo == 0)
		{
			//first attack pushes forward
			spawner.rb.AddForce(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y) * knockback, ForceMode.Impulse);

			SpawnProj(combo, spawner.facingDir, true);
		}
		else if (combo == 1)
		{
			SpawnProj(combo, spawner.facingDir, true);
		}
		
		combo += 1;
		if (combo >= 2)
		{
			combo = 0;
		}
	}

	public override void Charge()
	{
		base.Charge();
		Debug.Log("Charge");
	}

	public override void ReleaseCharge()
	{
		base.ReleaseCharge();
		Debug.Log("relCharge");
		combo = 2;

		spawner.rb.AddForce(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y) * knockback, ForceMode.Impulse);

		SpawnProj(combo, spawner.facingDir, true);
		combo = 0;
	}

	public override void OnTargetHit(Entity target, Projectile source, out bool hit)
	{
		base.OnTargetHit(target, source, out hit);
		if (combo == 1)
		{
			//second pushes back enemies //but with lower force
			target.rb.AddForce(new Vector3(source.facingDir.x, 0, source.facingDir.y) * knockback * 0.5f, ForceMode.Impulse);
		}
	}
}
