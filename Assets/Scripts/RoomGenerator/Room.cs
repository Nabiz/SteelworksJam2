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

    public bool cleared;
    public List<SpawnPoint> spawnPoints;
    public List<Enemy> enemies;

    public void SpawnEnemies()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            enemies.Add(spawnPoint.Spawn());
        }
        if (spawnPoints.Count == 0)
        {
            GameManager.Instance.ClearRoom();
            cleared = true;
            UnlockDoors();
        }
    }

    public void EnemyDied(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            GameManager.Instance.ClearRoom();
            cleared = true;
            UnlockDoors();
        }
    }

    void UnlockDoors()
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
