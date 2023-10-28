using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPistol : Weapon
{
	public override void OnTargetHit(Entity target, Projectile source) { }

	public override void Fire()
	{
		Instantiate(projectiles[0], transform.position, transform.rotation);
	}
}
