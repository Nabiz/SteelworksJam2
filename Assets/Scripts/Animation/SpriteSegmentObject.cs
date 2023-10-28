using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSegmentObject : SpriteSegment
{
    [SerializeField] Enums.Direction dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ChangeDirection()
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

    public override void SetDirection(Enums.Direction direct)
    {
        if (direct != dir)
        {
            dir = direct; //this has to be first!
            ChangeDirection();
            return;
        }
        dir = direct;
    }
}
