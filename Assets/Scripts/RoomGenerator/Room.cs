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
    public List<Enemy> enemies;

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

    public void EnemyDied(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            if (doorUp)
                doorUp.GetComponent<Door>().locked = false;
            if (doorDown)
                doorDown.GetComponent<Door>().locked = false;
            if (doorLeft)
                doorLeft.GetComponent<Door>().locked = false;
            if (doorRight)
                doorRight.GetComponent<Door>().locked = false;
        }
    }
}
