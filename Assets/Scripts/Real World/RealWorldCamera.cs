using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWorldCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;
    }
}
