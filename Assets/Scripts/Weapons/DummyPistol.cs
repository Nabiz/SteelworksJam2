using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPistol : Weapon
{
	public override void OnTargetHit(Entity target, Projectile source, out bool hit) 
	{
		base.OnTargetHit(target, source, out hit);
	}

	public override void Fire()
	{
		base.Fire();
		Debug.Log("fired with" + currentCooldown);
		SpawnProj(combo, spawner.facingDir, false);
	}
}
