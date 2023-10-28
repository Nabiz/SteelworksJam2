using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void Spawn(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform);
    }
}
