using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterData : MonoBehaviour
{

    public static MeterData instance; 
    Progress saved;
    public int meter;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        saved = GameObject.FindObjectOfType<Progress>();
        saved.Add(meter);
    }

    public void Add(int value)
    {
        meter += value;
        saved.Add(meter);
    }
}
