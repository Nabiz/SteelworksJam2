using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRogue : Player
{
	[SerializeField] private Slider hpSlider;

	protected override void OnCollisionEnter(Collision other)
    {
		base.OnCollisionEnter(other);
		hpSlider.value = HP;
    }
}
