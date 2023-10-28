using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEnemy : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float dashSpeed;
    protected override IEnumerator AI()
    {
        while (true)
        {
            for (float i = 0; i < Random.Range(2f, 3f); i += Time.deltaTime)
            {
                Move(facingDir);
                RotateAngle(2f);
                yield return null;
            }
            yield return new WaitForSeconds(1f);
            speed = dashSpeed;
            for (float i = 0; i < 1f; i += Time.deltaTime)
            {
                Move(facingDir);
                yield return null;
            }

            speed = normalSpeed;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    
}
