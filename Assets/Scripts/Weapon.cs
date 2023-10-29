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

    private void Awake()
	{
        for (int i = 0; i < projectiles.Count; ++i)
		{
            projectiles[i].gameObject.SetActive(false);
		}

        spawner = GetComponentInParent<Entity>();
	}

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    //if returned false then do not apply damage
    public virtual void OnTargetHit(Entity target, Projectile source, out bool hit)
	{
        hit = true;
        if (target == spawner)
		{
            hit = false;
		}
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

    public virtual void OnRoomChange()
	{

	}

    protected Projectile SpawnProj(int index, Vector2 facing, bool isChild)
    {
        Projectile proj = Instantiate(projectiles[index].gameObject).GetComponent<Projectile>();
        proj.rb = proj.GetComponent<Rigidbody>(); //do not ask me why, but for some reason THIS is faster then awake in proj.
        if (isChild)
		{
            proj.transform.SetParent(spawner.transform);
            proj.rb.isKinematic = true;
		}
        proj.gameObject.SetActive(true);
        proj.transform.position = new Vector3(transform.position.x + spawner.facingDir.x * proj.offset, transform.position.y, transform.position.z + spawner.facingDir.y * proj.offset);
        proj.transform.rotation = Quaternion.LookRotation(new Vector3(spawner.facingDir.x, 0, spawner.facingDir.y), Vector3.up);
        proj.facingDir = facing;
        proj.weapon = this;
        return proj.GetComponent<Projectile>();
    }
}
