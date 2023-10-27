using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
	private void Awake()
	{
		StartCoroutine(AI());
	}

	protected abstract IEnumerator AI();
}
