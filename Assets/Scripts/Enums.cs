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
        driver = 2,
        plumber = 3,
        builder = 4
    }
}
