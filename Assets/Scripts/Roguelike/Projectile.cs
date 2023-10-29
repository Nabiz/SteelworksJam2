using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 facingDir;
    public Rigidbody rb;

    public float offset;
    public float cooldown;
    public float speed;
    public float damage;
    public float lifetime;
    public bool destroyOnCollide;
    public Weapon weapon;
    
	private void Awake()
	{
        rb = gameObject.GetComponent<Rigidbody>();
    }
	private void Start()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(new Vector3(facingDir.x, 0, facingDir.y) * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Entity target = other.gameObject.GetComponentInParent<Entity>();
        if (target)
        {
                bool hit;
                if (target != null)
				{
                    weapon.OnTargetHit(target, this, out hit);
                    if (!hit)
                    {
                        return;
                    }
                    target.HP -= damage;
                    if (destroyOnCollide)
                        Destroy(gameObject);
                }
        }
    }
}
