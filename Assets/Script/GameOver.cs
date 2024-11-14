using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Setup() {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Off() {
        gameObject.SetActive(false);
    }
}
