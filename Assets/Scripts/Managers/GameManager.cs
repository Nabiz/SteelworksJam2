using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public float DistanceToPlayer(Vector3 vector3)
    {
        return Vector3.Distance(player.transform.position, vector3);
    }
}
