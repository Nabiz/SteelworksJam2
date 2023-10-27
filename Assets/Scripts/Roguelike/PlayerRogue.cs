using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRogue : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Move(Vector2 vector2)
	{
		base.Move(vector2);
	}

    //this does not "rotates" player, only sets it's sprite facing dir
	public override void Rotate(Vector2 vector2)
	{
		//get face direction

	}
}
