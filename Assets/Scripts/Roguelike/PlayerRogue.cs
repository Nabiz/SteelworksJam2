using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRogue : Player
{
	[SerializeField] private Slider hpSlider;
	//this does not "rotates" player, only sets it's sprite facing dir

	/*
	public override void Fire()
	{
		base.Fire(shootDir);
		rb.AddForce(shootDir * 10, ForceMode.Impulse);
		Debug.Log(shootDir);
	}
	*/
	protected override void OnCollisionEnter(Collision other)
    {
		base.OnCollisionEnter(other);
		hpSlider.value = HP;
    }
}
