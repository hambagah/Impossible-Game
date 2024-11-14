using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] Player player;
    public Image[] hearts;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < 3; i++)
        {
            Debug.Log(hearts[i]);
            if (i > player.lives)
                hearts[i].enabled = false;
            else 
                hearts[i].enabled = true;
        }*/
    }

    public void HealthUpdate(int count)
    {
        hearts[count].enabled = false;
    }
}
