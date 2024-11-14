using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] UFO[] ufos;

    public float ufoSpawnDelay = 0;
    public float spawnTimer = 5f;
    public float spawnChance = 3f;
    public int ufoNum;
    public float speedLow = 3;
    public float speedHigh = 12;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ufoSpawnDelay > spawnTimer)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (Random.Range(0f, 6f) > spawnChance)
                {
                    UFO ufo = Instantiate(ufos[ufoNum], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                    if (spawnPoints[i].transform.position.x > 0)
                        ufo.Flip();
                    ufo.SetSpeed(Random.Range(speedLow, speedHigh));
                }
            }
            ufoSpawnDelay = 0;
        }
        else
        {
            ufoSpawnDelay += Time.deltaTime;
        }
    }
}
