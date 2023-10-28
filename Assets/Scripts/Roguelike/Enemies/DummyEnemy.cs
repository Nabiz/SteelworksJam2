using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : Enemy
{

	protected override IEnumerator AI()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
		}
	}
}
