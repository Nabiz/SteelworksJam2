using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : Entity
{
	private void Awake()
	{
		StartCoroutine(AI());
	}

	IEnumerator AI()
	{
		while (true)
		{
			Fire();
			yield return new WaitForSeconds(1f);
		}
	}

}
