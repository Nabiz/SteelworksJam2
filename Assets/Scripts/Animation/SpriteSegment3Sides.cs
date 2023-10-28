using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSegment3Sides : SpriteSegment
{
    public Texture[] sides;
    private Material mainMat;

	private void Start()
	{
        mainMat = gameObject.GetComponent<MeshRenderer>().material;
	}

	public override void ChangeDirection()
    {
        if ((int)dir == 0)
        {
            mainMat.mainTexture = sides[0];
        }
        else if ((int)dir == 1)
        {
            mainMat.mainTexture = sides[1];
        }
        else if ((int)dir == 2)
        {
            mainMat.mainTexture = sides[2];
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if ((int)dir == 3)
        {
            mainMat.mainTexture = sides[2];
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}
