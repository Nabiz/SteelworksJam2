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
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Transform model;
    [SerializeField] Transform hoomanPrefab;
    [SerializeField] Transform electricianPrefab;
    [SerializeField] Transform gardenerPrefab;
    [SerializeField] Transform gangstaPrefab;
    [SerializeField] Transform medicPrefab;
    
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
                InstanciateModel(electricianPrefab);
                break;
            case Enums.NPCType.gangster:
                InstanciateModel(gangstaPrefab);
                break;
            case Enums.NPCType.gardener:
                InstanciateModel(gardenerPrefab);
                break;
            case Enums.NPCType.medic:
                InstanciateModel(medicPrefab);
                break;
            case Enums.NPCType.pedestrian:
                InstanciateModel(hoomanPrefab);
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
        if (navMeshAgent && navMeshAgent.isActiveAndEnabled)
            navMeshAgent.destination = target;
    }

    public void Die()
    {
        StopAllCoroutines();
        navMeshAgent.enabled = false;
        col.enabled = true;
        gameObject.AddComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(AI());
    }
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    void InstanciateModel(Transform prefab) {
        Transform instanciatedModel = Instantiate(prefab, model);
        instanciatedModel.localScale = Vector3.one * 0.6f;

        Renderer renderer = instanciatedModel.GetComponent<Renderer>();

        for (int i = 0; i < renderer.materials.Length; i++)
            if (renderer.materials[i].name.Contains("Clothes"))
                renderer.materials[i].color = RandomColor();
    }

    Color RandomColor() => new Color(Random.value, Random.value, Random.value);
}
