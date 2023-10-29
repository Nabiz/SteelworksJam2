using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;
    public Slider hpSlider;
    public GameObject gameOverScreen;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Slider GetHPSlider()
    {
        return hpSlider;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
