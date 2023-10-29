using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glaive : Weapon
{
	public float spread;
	public float thrust;
	public GameObject turret;
	public override void Fire()
	{
		base.Fire();
		if (combo == 0)
		{
			SpawnProj(combo, spawner.facingDir, true);
		}
		else if (combo == 1)
		{
			SpawnProj(combo, Quaternion.AngleAxis(-spread, Vector3.up) * new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y), true);
		}
		else if (combo == 2)
		{
			SpawnProj(combo, Quaternion.AngleAxis(spread, Vector3.up) * new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y), true);
		}
		else if (combo == 3)
		{
			spawner.rb.AddForce(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y) * thrust, ForceMode.Impulse);
			SpawnProj(combo, spawner.facingDir, true);

			combo = -1;
		}


		if (combo == 5) //normally unreachable state
		{
			//spin
			GameObject proj = SpawnProj(combo, new Vector2(0, 0), false);
			proj.gameObject.transform.position = turret.transform.position;
		}
		else
		{
			combo += 1;
		}
	}

	public override void ReleaseCharge()
	{
		base.ReleaseCharge();
		if (combo != 5) //if turret not set up
		{
			combo = 4;
			turret = SpawnProj(combo, new Vector2(0, 0), false);
			combo = 5;
		}
	}

	public override void OnTargetHit(Entity target, Projectile source, out bool hit)
	{
		base.OnTargetHit(target, source, out hit);
		if (source == turret && target == spawner) //pick up your own spear
		{
			Destroy(turret.gameObject);
			combo = 0;
			hit = false;
		}
		hit = true;
	}
}
