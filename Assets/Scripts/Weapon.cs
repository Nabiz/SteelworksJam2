using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected List<Projectile> projectiles;
    //[SerializeField] protected float cooldown; //proj schould be heaving cooldown

    [SerializeField] private float currentCooldown;
    [SerializeField] protected int combo;
    [SerializeField] public float charge;

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

    public virtual void OnTargetHit(Entity target, Projectile source)
	{

	}

    public virtual void Fire()
    {
        if (currentCooldown > 0)
            return;
        
        currentCooldown = projectiles[combo].cooldown;
    }

    public virtual void Charge()
	{

	}

    public virtual void ReleaseCharge()
	{

	}

    /*
    protected Projectile SpawnProj()
	{
        Projectile proj = Instantiate(projectiles[0].gameObject).GetComponent;
        proj.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * proj.offset, transform.position.y, transform.position.z + spawner.facingDir.y * proj.offset);
        return proj.GetComponent<Projectile>();
    }
    */
    protected Projectile SpawnProj(int index, Vector2 facing)
    {
        Projectile proj = Instantiate(projectiles[index].gameObject).GetComponent<Projectile>();
        proj.gameObject.SetActive(true);
        proj.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * proj.offset, transform.position.y, transform.position.z + spawner.facingDir.y * proj.offset);
        proj.transform.rotation = Quaternion.LookRotation(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y), Vector3.up);
        proj.facingDir = facing;
        return proj.GetComponent<Projectile>();
    }
}
