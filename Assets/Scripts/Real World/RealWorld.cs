using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RealWorld : MonoBehaviour
{
    public static RealWorld Instance;
    public List<NPC> npcs;
    public GameObject npcPrefab;
    public Transform npcParent;
    public int npcToGenerate;
    public float worldBoundsUp;
    public float worldBoundsRight;
    public float worldBoundsDown;
    public float worldBoundsLeft;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateNPCs();
    }

    void GenerateNPCs()
    {
        for (int i = 0; i < npcToGenerate; i++)
        {
            npcs.Add(Instantiate(npcPrefab, new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), Quaternion.identity, npcParent).GetComponent<NPC>());
        } 
    }
}
