using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Enemy
{
    void Update()
    {
        WaitStateHandler();

        if (state == 0)
        {
            Vector3 tmp = Vector3.Normalize(player.transform.position - gameObject.transform.position);
            facingDir = new Vector2(tmp.x, tmp.z);
            Move(facingDir);
            Attack();
        }
    }
}
