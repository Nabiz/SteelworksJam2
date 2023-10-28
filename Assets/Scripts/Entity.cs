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
    
    [SerializeField] protected Weapon weapon;
	[SerializeField] public Rigidbody rb;
	public Vector2 facingDir;
	
    private void Awake()
    {
	    rb = GetComponent<Rigidbody>();
		weapon = GetComponentInChildren<Weapon>();
		weapon.spawner = this;
    }

	public virtual void Move(Vector2 vector2)
	{
		
	}

	public virtual void Rotate(Vector2 vector2)
	{
		
	}

	public virtual void Die()
    {
		Destroy(gameObject);
    }
    
    
}
