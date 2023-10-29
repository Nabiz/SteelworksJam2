using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenMirror : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        //get player weapon
        weapon = Instantiate(GameObject.FindFirstObjectByType<PlayerRogue>().weapon, gameObject.transform);
        
        //freeze AI as the head start
        
    }



}
