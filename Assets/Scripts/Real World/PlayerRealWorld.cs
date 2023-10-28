using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRealWorld : Player
{
    private NPC takenOverNPC;
    [SerializeField] private float propsDetectionRadius = 5f;
    [SerializeField] private Prop[] props;
    [SerializeField] private NPC[] npcs;
    
    public override void Start ()
    {
        base.Start();
        props = FindObjectsOfType<Prop>();
        npcs = FindObjectsOfType<NPC>();
    }

    private void Update()
    {
        if (!takenOverNPC)
            return;
        
        takenOverNPC.transform.position = transform.position + Vector3.up * 0.5f;
    }

    public void Takeover()
    {
        if (takenOverNPC)
        {
            GameManager.Instance.EnterRoguelike();
            return;
        }
        
        NPC closestNPC = null;
        float closestDistance = Mathf.Infinity;
        
        foreach (NPC npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (!(distance < closestDistance))
                continue;
            
            closestDistance = distance;
            closestNPC = npc;
        }

        if (!closestNPC)
            return;
        
        if (closestDistance > 2f)
            return;

        takenOverNPC = closestNPC;
        takenOverNPC.StopAllCoroutines();
        currentSpeed = takeoverSpeed;
    }

    public void ReleaseNPC()
    {
        if (!takenOverNPC)
            return;

        takenOverNPC.StartCoroutine(takenOverNPC.AI());
        takenOverNPC = null;
        currentSpeed = normalSpeed;
    }

    public List<Prop> GetNearestProps()
    {
        Debug.Log("search for nearest props");
        List<Prop> nearestProps = new List<Prop>();

        foreach (Prop prop in props)
        {
            if (Vector3.Distance(transform.position, prop.transform.position) < propsDetectionRadius)
                nearestProps.Add(prop);
        }

        Debug.Log($"{nearestProps.Count}");
        return nearestProps;
    }

    void OnDrawGizmos () {
        Gizmos.DrawWireSphere(transform.position, propsDetectionRadius);
    }
}
