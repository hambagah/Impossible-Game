using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterData : MonoBehaviour
{

    public static MeterData instance; 
    public int meter;
    Progress saved;
    
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
        saved = GameObject.Find("GameManager").GetComponent<Progress>();
        saved.Add(meter);
    }

    void Update()
    {
        if (saved == null)
        {        
            saved = GameObject.Find("GameManager").GetComponent<Progress>();
            saved.Add(meter);
        }
    }

    public void Add(int value)
    {
        meter += value;
        Debug.Log(saved);
        saved.Add(meter);
    }
}
