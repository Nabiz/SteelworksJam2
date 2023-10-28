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
    public float pierceCooldown;
    public int pierceLifetime;
    public Sprite sprite;
    public Weapon weapon;
    
    [SerializeField] private float currentPierceLifetime;

	private void Awake()
	{
        rb = gameObject.GetComponent<Rigidbody>();
    }
	private void Start()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(new Vector3(facingDir.x, 0, facingDir.y) * speed, ForceMode.Impulse);
    }

    //*
    private void Update()
    {
        //transform.Translate(new Vector3(facingDir.x, 0, facingDir.y) * speed * Time.deltaTime);
        if (currentPierceLifetime > 0)
        {
            currentPierceLifetime -= Time.deltaTime;
        }
    }
    //*/

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaaaaaa");
        if (other.gameObject.CompareTag("Entity"))
        {
            Debug.Log("pierce time destrys");
            if (currentPierceLifetime >= 0)
            {
                Entity target = other.gameObject.GetComponentInParent<Entity>();
                bool hit;
                if (target != null)
				{
                    weapon.OnTargetHit(target, this, out hit);
                    if (!hit)
                    {
                        return;
                    }
                    target.HP -= damage;
                    currentPierceLifetime = pierceCooldown;
                }

            }

            if (destroyOnCollide)
                Destroy(gameObject);
        }
    }
}
