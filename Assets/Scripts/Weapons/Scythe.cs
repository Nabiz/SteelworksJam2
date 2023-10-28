using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
	public float knockback;
	public override void Fire()
	{
		base.Fire();
		float offset = 1;
		if (combo == 0)
		{
			//first attack pushes forward
			spawner.rb.AddForce(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y) * knockback, ForceMode.Impulse);

			//GameObject scythe = Instantiate(projectiles[0].gameObject);
			//scythe.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * projectiles[0].offset, transform.position.y, transform.position.z + spawner.facingDir.y * projectiles[0].offset);
			SpawnProj(combo, spawner.facingDir);
		}
		else if (combo == 1)
		{
			//GameObject scythe = Instantiate(projectiles[0].gameObject);
			//scythe.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * projectiles[0].offset, transform.position.y, transform.position.z + spawner.facingDir.y * projectiles[0].offset);
			SpawnProj(combo, spawner.facingDir);
		}


		combo += 1;
		if (combo >= projectiles.Count)
		{
			combo = 0;
		}
	}

	public override void OnTargetHit(Entity target, Projectile source)
	{
		if (combo == 1)
		{
			//second pushes back enemies //but with lower force
			target.rb.AddForce(new Vector3(source.facingDir.x, 0, source.facingDir.y) * knockback * 0.5f, ForceMode.Impulse);
		}
	}
}
