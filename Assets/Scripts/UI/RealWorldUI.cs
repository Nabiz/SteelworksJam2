using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealWorldUI : MonoBehaviour
{
    public static RealWorldUI Instance;
    public TextMeshProUGUI score;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public TextMeshProUGUI GetScoreText()
    {
        return score;
    }
}
