using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRealWorld : Player
{
    public NPC takenOverNPC;
    [SerializeField] private float propsDetectionRadius = 5f;
    [SerializeField] private Prop[] props;
    [SerializeField] private NPC[] npcs;

    [SerializeField] private GameObject model;
    
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
        
        takenOverNPC.transform.position = transform.position + Vector3.up * 0.2f;
    }

    public void Takeover()
    {
        if (takenOverNPC)
        {
            GameManager.Instance.EnterRoguelike();
            UberTutorial.Instance.SetTutorialText("WASD to move\nLMB to attack\n1, 2, 3 key for weapon change\nClear 4 rooms to force controlled pedestrian to commit suicide");
            SoundManager.Instance.PlayMusic(2);
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
        ShowModel(false);
        UberTutorial.Instance.SetTutorialText("Now you are in control\nWASD to move\nRMB to let him/her go\nGuide pedestrian to dangerous place\nSPACE to go inside mind and force him/her to commit suicide");
        SoundManager.Instance.PlaySound(0);
    }

    public void ReleaseNPC()
    {
        if (!takenOverNPC)
            return;

        takenOverNPC.StartCoroutine(takenOverNPC.AI());
        takenOverNPC = null;
        currentSpeed = normalSpeed;
        ShowModel(true);
        transform.position += Vector3.up * 0.2f;
        UberTutorial.Instance.SetTutorialText("WASD to move\nGo near pedestrian and hit Space to take over control\n");
    }

    public List<Prop> GetNearestProps()
    {
        List<Prop> nearestProps = new List<Prop>();

        foreach (Prop prop in props)
        {
            if (Vector3.Distance(transform.position, prop.transform.position) < propsDetectionRadius)
                nearestProps.Add(prop);
        }
        
        return nearestProps;
    }

    void ShowModel(bool status)
    {
        if (status)
            model.SetActive(true);
        else
            model.SetActive(false);
    }
}
