using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterData : MonoBehaviour
{

    public static MeterData instance; 
    public int meter;
    public float hp;
    Progress saved;
    EnemyHealth boss;
    
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
        /*if (boss == null)
        {        
            boss = GameObject.Find("Boss").GetComponent<EnemyHealth>();
            boss.health = hp;
            boss.currHealth = hp;
        }*/
    }

    public void Add(int value)
    {
        meter += value;
        saved.Add(meter);
    }

    public void Health(float bossHealth)
    {
        //hp = bossHealth;
    }
}
