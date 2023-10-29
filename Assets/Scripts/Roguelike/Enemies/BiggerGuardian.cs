using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerGuardian : Enemy
{
    private void Update()
    {
        WaitStateHandler();

        if (state == 0)
        {
            facingDir = Vector2.up;
            Attack();
        }
    }
}
