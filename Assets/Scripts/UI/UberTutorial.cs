using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UberTutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tutorialText;

    public static UberTutorial Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTutorialText(string text)
    {
        tutorialText.text = text;
    }
}
