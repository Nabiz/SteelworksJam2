using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAI : MonoBehaviour
{
    private Enemy enemy;
    // Start is called before the first frame update
    void Awake()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
