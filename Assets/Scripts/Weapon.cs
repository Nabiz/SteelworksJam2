using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected List<GameObject> projectiles;
    [SerializeField] protected float cooldown;

    [SerializeField] private float currentCooldown;

    public Entity spawner;
    
    // [SerializeField] protected List<GameObject> createdProjectiles;
    // [SerializeField] protected float projectilesLimit;
    
    float cooldownTimer;

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public virtual void Fire()
    {
        if (currentCooldown > 0)
            return;
        
        currentCooldown = cooldown;
    }

    /*
    void CleanupCreatedProjectiles()
    {
        for (int i = 0; i < createdProjectiles.Count;)
        {
            if (createdProjectiles[i])
            {
                i++;
            }
            else
            {
                createdProjectiles.RemoveAt(i);
            }
        }
    }
    */
}
