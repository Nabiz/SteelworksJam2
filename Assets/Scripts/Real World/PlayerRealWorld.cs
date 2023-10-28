using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealWorld : Player
{
    private NPC takenOverNPC;
    [SerializeField] private float propsDetectionRadius = 5f;
    
    private void Update()
    {
        if (!takenOverNPC)
            return;
        
        takenOverNPC.transform.position = transform.position;
    }

    public void Takeover()
    {
        if (takenOverNPC)
        {
            GameManager.Instance.EnterRoguelike();
            return;
        }
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        NPC closestNPC = null;
        float closestDistance = Mathf.Infinity;
        
        foreach (Collider c in colliders)
        {
            float distance = Vector3.Distance(transform.position, c.transform.position);
            if (!(distance < closestDistance))
                continue;
            
            closestDistance = distance;
            closestNPC = c.GetComponent<NPC>();
        }

        if (!closestNPC)
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
        List<Prop> nearestProps = new List<Prop>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, propsDetectionRadius);

        foreach (Collider c in colliders)
        {
            Prop prop = c.GetComponent<Prop>();
            if (prop)
                nearestProps.Add(prop);
        }

        return nearestProps;
    }
}
