using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int meter;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Player target;
    [SerializeField] GameObject background;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject ten1;
    [SerializeField] GameObject ten2;
    [SerializeField] GameObject ten3;
    [SerializeField] GameObject ten4;
    [SerializeField] GameObject eyes;

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
        if (meter > 200) {
            enemyHealth.eShootTime = 2;
            enemyHealth.eSpreadTime = 5;
            enemyHealth.eBulletSpeed = 4;
            enemyHealth.eSpreadSpeed = 4;
            target.shootTime = -0.5f;
            target.damage = 2f;
        }

        if (meter > 300) {
            ten1.SetActive(false); 
            ten3.SetActive(false);
            enemyHealth.bulletCount = 6;
            target.shootTime = -0.8f;
            target.damage = 3f;
        }

        if (meter > 400) {
            target.shootTime = -1f;
            target.damage = 4f;
        }

        if (meter > 500) {
            ten2.SetActive(false); 
            ten4.SetActive(false);
            background.SetActive(false);
        }

        if (meter > 600) {
            enemyHealth.True();
        }

        if (meter > 700) {
            eyes.SetActive(false);
            enemyHealth.eSpreadSpeed = 2;
        }

        if (meter > 800) {
            background2.SetActive(true);
        }

        if (meter > 900) {

        }

        if (meter > 1000) {
            target.trueForm = true;
        }
    }

    public void Add(int value)
    {
        meter += value;
    }
}
