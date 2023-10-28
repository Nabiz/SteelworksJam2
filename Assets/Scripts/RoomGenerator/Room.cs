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
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            spawnPoint.Spawn(enemiesInRoom[Random.Range(0, enemiesInRoom.Count)]);
        }
    }
}
