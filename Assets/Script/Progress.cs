using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int meter;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Player target;

    void Start()
    {
        meter = 0;    
        enemyHealth = enemyHealth.GetComponent<EnemyHealth>();
        target = target.GetComponent<Player>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (meter > 100) {
            enemyHealth.eShootTime = 4;
        }

        if (meter > 200) {

        }

        if (meter > 300) {

        }

        if (meter > 400) {

        }

        if (meter > 500) {

        }

        if (meter > 600) {

        }

        if (meter > 700) {

        }

        if (meter > 800) {

        }

        if (meter > 900) {

        }

        if (meter > 1000) {

        }
    }

    public void Add(int value)
    {
        meter += value;
    }
}
