using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Enemy
{
    private void Update()
    {
        WaitStateHandler();

        if(state == 0)
        {
            facingDir = Vector3.Normalize(player.transform.position - gameObject.transform.position);

            Attack();
        }
    }
}
