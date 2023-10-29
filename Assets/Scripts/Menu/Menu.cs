using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        SoundManager.Instance.musicAudioSource.mute = false;
    }

    public void StartIntro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
