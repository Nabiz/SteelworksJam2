using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShowdown : MonoBehaviour
{
    public Material material;
    [SerializeField]private int worldPosId;
    public Vector4 WorldPhase;

    public float scrollSpeed;
    public float shineMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        //get id of value
        worldPosId = Shader.PropertyToID("_WorldPhase");
    }

    // Update is called once per frame
    void Update()
    {
        WorldPhase.y = (Mathf.Sin(Time.fixedTime) + 1) * shineMagnitude;
        WorldPhase.z += Time.deltaTime * scrollSpeed;

        //here place values in a shader
        material.SetVector(worldPosId, WorldPhase);
    }
}
