using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : Enemy
{

	protected override IEnumerator AI()
	{
		while (true)
		{
			Fire();
			yield return new WaitForSeconds(1f);
		}
	}
}
