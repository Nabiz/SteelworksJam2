using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPistol : Weapon
{
	public override void Fire()
	{
		base.Fire();
		Instantiate(projectiles[0], transform.position, transform.rotation);
	}
}