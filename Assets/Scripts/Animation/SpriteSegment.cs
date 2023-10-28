using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSegment : MonoBehaviour
{
    [SerializeField] Enums.Direction dir;

    SpriteAnimator animator;
    
    float progress = -1f;

    bool reverse = false;

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

	// Start is called before the first frame update
	void Awake()
    {
        animator = GetComponentInParent<SpriteAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime * animator.AnimationSpeed * (reverse ? -1f : 1f);

        if (!reverse && progress >= 1f)
        {
            progress = 1f;
            reverse = true;
        } else if (reverse && progress <= 0f)
        {
            progress = 0f;
            reverse = false;
        }

        Animate();
    }

    public void ChangeDirection()
	{
        Vector3 newRot = new Vector3(gameObject.transform.rotation.eulerAngles.x, 0, gameObject.transform.rotation.eulerAngles.z);
        if ((int)dir == 0)
        {
            newRot.y = 0;
        }
        else if ((int)dir == 1)
        {
            newRot.y = 90;
        }
        else if ((int)dir == 2)
        {
            newRot.y = 180;
        }
        else if ((int)dir == 3)
		{
            newRot.y = 270;
        }

        transform.eulerAngles = newRot;
    }

    public virtual void SetDirection(Enums.Direction direct)
	{
        if (direct != dir)
		{
            dir = direct; //this has to be first!
            ChangeDirection();
            return;
        }
        dir = direct;
    }

    void Animate() {
        Vector3 positionOffset = new Vector3(progress, 0f, Mathf.Abs((float)Math.Sin(2 * Math.PI * progress)));
        transform.localPosition = originalPosition + positionOffset;
    }

    public void Init(float offset) {
        if (progress != -1f) return;

        if (offset > 0f && offset < 1f) {
            progress = offset;
            reverse = true;
        }
    }
}
