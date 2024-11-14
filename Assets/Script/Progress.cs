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
    [SerializeField] UFOSpawner spawner;

    /*public static Progress instance; 
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }*/

    void Start()
    {
        meter = 0;    
        enemyHealth = GameObject.FindObjectOfType<EnemyHealth>();
        target = GameObject.FindObjectOfType<Player>();
        ten1 = GameObject.Find("Tentacles1");
        ten2 = GameObject.Find("Tentacles2");
        ten3 = GameObject.Find("Tentacles3");
        ten4 = GameObject.Find("Tentacles4");
        eyes = GameObject.Find("Eyes");
        spawner = GameObject.FindObjectOfType<UFOSpawner>();
    }

    void Update()
    {
        if (meter > 200) {
            enemyHealth.eShootTime = 2;
            enemyHealth.eSpreadTime = 5;
            enemyHealth.eBulletSpeed = 4;
            enemyHealth.eSpreadSpeed = 4;
            target.shootTime = -0.3f;
            target.damage = 2f;
            spawner.spawnChance = 2;
            spawner.spawnTimer = 7;
        }

        if (meter > 300) {
            ten1.SetActive(false); 
            ten3.SetActive(false);
            enemyHealth.bulletCount = 6;
            target.shootTime = -0.5f;
            target.damage = 3f;
        }

        if (meter > 400) {
            target.shootTime = -.7f;
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
        meter = value;
    }
}
