using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRogue : Player
{
	protected override void OnCollisionEnter(Collision other)
    {
		base.OnCollisionEnter(other);
		UI.Instance.hpSlider.value = HP;
    }
}
