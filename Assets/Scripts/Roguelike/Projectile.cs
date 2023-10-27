using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float lifetime;
    public bool destroyOnCollide;
    public float pierceCooldown;
    public int pierceLifetime;
    public Sprite sprite;
    
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
                other.gameObject.GetComponent<Entity>().HP -= damage;
                currentPierceLifetime = pierceCooldown;
            }

            if (destroyOnCollide)
                Destroy(gameObject);
        }
    }
}
