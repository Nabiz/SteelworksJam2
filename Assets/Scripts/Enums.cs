using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum Direction
    {
        up = 0,
        down = 1,
        left = 2,
        right = 3
    }

    public enum GameState
    {
        realWorld,
        roguelike
    }
    
    public enum NPCType
    {
        none = 0,
        electrician = 1,
        gangster = 2,
        gardener = 3,
        medic = 4,
        pedestrian = 5,
    }
}
