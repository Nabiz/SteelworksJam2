using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leszy : Enemy
{
	public float AwarnessDist;
	private void FixedUpdate()
	{
        WaitStateHandler();
		if (state == 0) //leszy tries to attack //weapon determines cooldowns
		{
			facingDir = Vector3.Normalize(gameObject.transform.position - player.transform.position);
			Attack();
			Debug.Log("imma attacking");
		}
		else if (state == 1)//leszy is not attacking, player too close
		{
			facingDir = new Vector3(0, 0, -1); //face down to indicate disability
		}

		//state change
		float playerDist = Vector3.Distance(player.transform.position, gameObject.transform.position);
		if (playerDist < AwarnessDist)
		{
			state = 1;
		}
		else
		{
			state = 0;
		}
	}


}