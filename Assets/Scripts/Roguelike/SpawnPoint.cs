using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    
    public Enemy Spawn()
    {
        return Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
    }
}
