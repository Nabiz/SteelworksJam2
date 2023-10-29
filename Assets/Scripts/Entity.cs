using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour
{
	[SerializeField] private float hp;
    public float HP {
	    get { return hp; }
	    set
	    {
		    // Debug.Log(name);
		    if (value <= 0)
			    Die();
		    
		    hp = value;
	    }
    }
    
    public Weapon weapon;
	[SerializeField] public Rigidbody rb;
	public Vector2 facingDir;
	
    private void Awake()
    {
	    rb = GetComponent<Rigidbody>();
		if (weapon == null)
		{
			weapon = GetComponentInChildren<Weapon>();
		}
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
