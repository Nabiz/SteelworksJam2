using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Enums.GameState gameState = Enums.GameState.realWorld;

    public float score;
    public int clearedRooms;
    
    [SerializeField] private GameObject realWorld;
    [SerializeField] private GameObject roguelikeWorld;
    [SerializeField] private RoomGenerator roomGenerator;
    [SerializeField] private PlayerRealWorld realWorldPlayer;
    [SerializeField] private PlayerRogue roguelikePlayer;
    [SerializeField] private Camera realWorldCamera;
    [SerializeField] private Camera roguelikeCamera;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            realWorldPlayer.isControlled = true;
            roguelikePlayer.isControlled = false;
        }
        else
            Destroy(gameObject);
    }

    public Player GetPlayer()
    {
        switch (gameState)
        {
            case Enums.GameState.realWorld:
                return realWorldPlayer;
            case Enums.GameState.roguelike:
                return roguelikePlayer;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Camera GetCamera()
    {
        switch (gameState)
        {
            case Enums.GameState.realWorld:
                return realWorldCamera;
            case Enums.GameState.roguelike:
                return roguelikeCamera;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public float DistanceToPlayer(Vector3 vector3)
    {
        return Vector3.Distance(GetPlayer().transform.position, vector3);
    }
    
    public void EnterRoguelike()
    {
        gameState = Enums.GameState.roguelike;
        
        // realWorldPlayer.isControlled = false;
        // roguelikePlayer.isControlled = true;
        realWorld.SetActive(false);
        roomGenerator.Generate(realWorldPlayer.GetNearestProps());
        roguelikeWorld.SetActive(true);
    }

    public void ClearRoom()
    {
        clearedRooms++;
        if (clearedRooms == 3)
        {
            EnterRealWorld();
            clearedRooms = 0;
        }
    }

    public void EnterRealWorld()
    {
        gameState = Enums.GameState.realWorld;
        // realWorldPlayer.isControlled = true;
        // roguelikePlayer.isControlled = false;
        roomGenerator.Cleanup();
        realWorld.SetActive(true);
        roguelikeWorld.SetActive(false);
        score += 1;
        RealWorldUI.Instance.GetScoreText().text = $"Harvested souls: {score}";
        ((PlayerRealWorld)GetPlayer()).takenOverNPC.Die();
        ((PlayerRealWorld)GetPlayer()).ReleaseNPC();
    }
}
