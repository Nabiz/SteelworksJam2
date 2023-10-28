using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 facingDir;

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

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
        if (currentPierceLifetime > 0)
        {
            currentPierceLifetime -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Entity"))
        {
            if (currentPierceLifetime >= 0)
            {
                Entity target = other.gameObject.GetComponent<Entity>();
                target.HP -= damage;
                weapon.OnTargetHit(target, this);
                currentPierceLifetime = pierceCooldown;
            }

            if (destroyOnCollide)
                Destroy(gameObject);
        }
    }
}
