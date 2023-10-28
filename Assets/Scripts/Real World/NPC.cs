using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    private Enums.NPCType npcType;
    private NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GenerateNPC();
        StartCoroutine(AI());
    }

    void GenerateNPC()
    {
        npcType = (Enums.NPCType)Random.Range(1, Enum.GetNames(typeof(Enums.NPCType)).Length);
        switch (npcType)
        {
            case Enums.NPCType.none:
                break;
            case Enums.NPCType.electrician:
                GetComponentInChildren<Renderer>().material.color = Color.blue;
                break;
            case Enums.NPCType.driver:
                GetComponentInChildren<Renderer>().material.color = Color.magenta;
                break;
            case Enums.NPCType.plumber:
                GetComponentInChildren<Renderer>().material.color = Color.green;
                break;
            case Enums.NPCType.builder:
                GetComponentInChildren<Renderer>().material.color = Color.yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected virtual IEnumerator AI()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 10f));
            GoTo(new Vector3(Random.Range(RealWorld.Instance.worldBoundsLeft, RealWorld.Instance.worldBoundsRight), 0, Random.Range(RealWorld.Instance.worldBoundsDown, RealWorld.Instance.worldBoundsUp)));
        }
    }

    void GoTo(Vector3 target)
    {
        navMeshAgent.destination = target;
    }
}
