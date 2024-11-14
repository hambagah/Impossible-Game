using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] Progress progress;
    private int save;

    public void Restart(string stageToPlay) 
    {
        save = progress.meter;
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Single);
        Time.timeScale = 1;
        progress.Add(save);
    }
}
