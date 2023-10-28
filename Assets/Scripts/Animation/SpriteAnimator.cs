using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
	private SpriteSegment[] sprites;
	private void Awake()
	{
		sprites = gameObject.GetComponentsInChildren<SpriteSegment>(includeInactive: false);
	}

	// Update is called once per frame
	void Update()
	{
        
	}

	public void SetDirectionAll(Enums.Direction dir)
	{
		for (int i = 0; i < sprites.Length; ++i) //then make it check if sprite schould react to dir change
		{
			sprites[i].SetDirection(dir);
		}
	}
}