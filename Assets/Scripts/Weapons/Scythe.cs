using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
	public override void Fire()
	{
		Instantiate(projectiles[0], transform.position, transform.rotation);
	}
}
