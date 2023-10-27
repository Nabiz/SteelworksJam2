using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	private float hp;
    public float HP {
	    get { return hp; }
	    set
	    {
		    if (value <= 0)
			    Die();
		    
		    hp = value;
	    }
    }
    
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
	    weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void Fire()
    {
	    if (!weapon)
		    return;
		weapon.Fire();
    }

    public virtual void Die()
    {
		Destroy(gameObject);
    }
    
    
}
