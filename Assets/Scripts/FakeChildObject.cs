using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeChildObject : MonoBehaviour
{
    public Transform pivot;

    // Update is called once per frame
    void Update()
    {
        if (pivot != null)
		{
            gameObject.transform.position = pivot.transform.position;
		}
    }
}
