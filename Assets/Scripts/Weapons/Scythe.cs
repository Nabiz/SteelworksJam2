using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Weapon
{
	public override void Fire()
	{
		base.Fire();
		spawner.rb.AddForce(spawner.facingDir, ForceMode.Impulse);
		GameObject scythe = Instantiate(projectiles[0]);
		scythe.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * 3, transform.position.y, transform.position.z + spawner.facingDir.y * 3);
	}
}
