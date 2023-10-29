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
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rb;
    
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
            case Enums.NPCType.gangster:
                GetComponentInChildren<Renderer>().material.color = Color.green;
                break;
            case Enums.NPCType.gardener:
                GetComponentInChildren<Renderer>().material.color = Color.red;
                break;
            case Enums.NPCType.medic:
                GetComponentInChildren<Renderer>().material.color = Color.yellow;
                break;
            case Enums.NPCType.pedestrian:
                GetComponentInChildren<Renderer>().material.color = Color.white;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public virtual IEnumerator AI()
    {
        while (true)
        {
            GoTo(new Vector3(Random.Range(RealWorld.Instance.worldBoundsLeft, RealWorld.Instance.worldBoundsRight), 0, Random.Range(RealWorld.Instance.worldBoundsDown, RealWorld.Instance.worldBoundsUp)));
            yield return new WaitForSeconds(Random.Range(1f, 10f));
        }
    }

    void GoTo(Vector3 target)
    {
        navMeshAgent.destination = target;
    }

    public void Die()
    {
        Destroy(navMeshAgent);
        collider.enabled = true;
        gameObject.AddComponent<Rigidbody>();
    }
}
