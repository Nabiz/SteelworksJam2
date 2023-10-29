using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Enemy Spawn(GameObject enemyToSpawn)
    {
        return Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
    }
}
