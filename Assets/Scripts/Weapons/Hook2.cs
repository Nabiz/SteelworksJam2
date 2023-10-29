using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook2 : Weapon
{
	GameObject HookTip;
	public float pullStrength;
	public override void Fire()
	{
		
		if (combo == 0)
		{
			base.Fire();
			if (needsReload)
			{
				return;
			}
			HookTip = SpawnProj(combo, new Vector2(0, 0), false);
		}
		if (combo == 1)
		{
			HookTip.GetComponent<Projectile>().rb.velocity = Vector3.zero;
		}
		else if (combo == 2) //lunch towards hook
		{
			spawner.rb.AddForce(Vector3.Normalize(HookTip.transform.position - spawner.transform.position) * pullStrength * Vector3.Distance(spawner.transform.position, HookTip.transform.position), ForceMode.Impulse);
			Destroy(HookTip.gameObject);
		}
		combo++;
		if (combo >= 3)
		{
			combo = 0;
		}
	}
}
