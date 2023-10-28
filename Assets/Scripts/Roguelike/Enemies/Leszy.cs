using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leszy : Enemy
{
    [SerializeField] private Sprite front;
    [SerializeField] private Sprite back;
    [SerializeField] private Sprite left;

    private Player player;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        player = GameManager.Instance.GetPlayer();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector3 vecToPlayer = player.gameObject.transform.position - transform.position;
        if (System.Math.Abs(vecToPlayer.x) >= System.Math.Abs(vecToPlayer.z))
        {
            spriteRenderer.sprite = left;
            if (vecToPlayer.x < -0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            spriteRenderer.flipX = false;
            if (vecToPlayer.z < -0.01f)
            {
                spriteRenderer.sprite = front;
            }
            else
            {
                spriteRenderer.sprite = back;
            }
        }
    }

    protected override IEnumerator AI()
    {
        yield return null;
    }
}