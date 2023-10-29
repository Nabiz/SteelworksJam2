using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerWeapon : Weapon
{
    public override void OnTargetHit(Entity target, Projectile source, out bool hit)
    {
        base.OnTargetHit(target, source, out hit);
    }

    public Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    public override void Fire()
    {
        base.Fire();
        if (needsReload) return;

        //Debug.Log("fired with" + currentCooldown);
        if (combo == 0)
        {
            SpawnProj(combo, Vector2.up, false);
            SpawnProj(combo, Vector2.left, false);
            SpawnProj(combo, Vector2.down, false);
            SpawnProj(combo, Vector2.right, false);
        }
        else if (combo == 1)
        {
            SpawnProj(combo, Rotate(Vector2.up, 45), false);
            SpawnProj(combo, Rotate(Vector2.left, 45), false);
            SpawnProj(combo, Rotate(Vector2.down, 45), false);
            SpawnProj(combo, Rotate(Vector2.right, 45), false);
        }

        combo++;
        if (combo >= projectiles.Count)
        {
            combo = 0;
        }
    }
}
