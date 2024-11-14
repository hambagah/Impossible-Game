using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public void StartGame(string stageToPlay) 
    {
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void ExitGame() {
        Application.Quit();
    }
}
