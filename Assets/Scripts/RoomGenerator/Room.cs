using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorUp;
    public GameObject doorDown;
    public GameObject doorRight;
    public GameObject doorLeft;

    public List<SpawnPoint> spawnPoints;

    public void SpawnEnemies(List<GameObject> enemiesInRoom)
    {
        Debug.Log($"spawn {enemiesInRoom.Count} enemies");
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            if (enemiesInRoom.Count == 0)
                break;
            spawnPoint.Spawn(enemiesInRoom[Random.Range(0, enemiesInRoom.Count - 1)]);
        }
    }
}
