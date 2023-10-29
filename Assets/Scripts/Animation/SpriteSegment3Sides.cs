using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSegment3Sides : SpriteSegment
{
    public Texture[] sides;

    [SerializeField] Vector3Int layers;

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
            transform.localPosition = new Vector3(transform.localPosition.x, layers.x * 0.2f, transform.localPosition.z);
        }
        else if ((int)dir == 1)
        {
            mainMat.mainTexture = sides[1];
            transform.localPosition = new Vector3(transform.localPosition.x, layers.y * 0.2f, transform.localPosition.z);
        }
        else if ((int)dir == 2)
        {
            mainMat.mainTexture = sides[2];
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x, layers.z * 0.2f, transform.localPosition.z);
        }
        else if ((int)dir == 3)
        {
            mainMat.mainTexture = sides[2];
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x, layers.z * 0.2f, transform.localPosition.z);
        }
    }
}
