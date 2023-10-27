using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
	[SerializeField] protected Rigidbody rb;
	
    private void Awake()
    {
	    rb = GetComponent<Rigidbody>();
		weapon = GetComponentInChildren<Weapon>();
    }

	public virtual void Move(Vector2 vector2)
	{
		
	}

	public virtual void Rotate(Vector2 vector2)
	{
		
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
