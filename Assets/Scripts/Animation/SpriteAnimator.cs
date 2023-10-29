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

	public void SetDirectionAll(Vector2 dir)
	{
		if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
		{
			if (dir.x > 0)
			{
				this.SetDirectionAll(Enums.Direction.right);
			}
			else
			{
				this.SetDirectionAll(Enums.Direction.left);
			}
		}
		else
		{
			if (dir.y > 0)
			{
				this.SetDirectionAll(Enums.Direction.up);
			}
			else
			{
				this.SetDirectionAll(Enums.Direction.down);
			}
		}
	}

	public void SetDirectionAll(Enums.Direction dir)
	{
		for (int i = 0; i < sprites.Length; ++i) //then make it check if sprite schould react to dir change
		{
			sprites[i].SetDirection(dir);
		}
	}
}