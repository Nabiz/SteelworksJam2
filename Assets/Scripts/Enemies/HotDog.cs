using System.Collections;
using UnityEngine;

public class HotDog : Enemy
{
	[SerializeField] private Animator animator;
	
	protected override IEnumerator AI()
	{
		while (true)
		{
			// TODO skocz
			// w trakcie skoku strzelaj
			// kiedy jest daleko skacze w stronę przeciwnika
			// kiedy jest blisko odskakuje
			// skok jest niedokładny
			yield return null;
		}
	}

	void Jump()
	{
		// TODO
	}
}