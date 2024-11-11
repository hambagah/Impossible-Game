using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 3;
    public float speed;
    private bool invul = false;
    private float invulTime;
    private float delay;
    public float shootTime;
    
    public Transform bulletLocation;
    public Bullet bulletPrefab;

    [SerializeField] Movement playerMove;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && delay > 0)
        {
            Instantiate(bulletPrefab, bulletLocation.position, transform.rotation);
            delay = shootTime;
        }
        else 
            delay += Time.deltaTime;

        if (invul) 
        {
            invulTime += Time.deltaTime;
        }
        else if (invulTime > 3f)
        {
            invul = false;
        }
    }

    public void Hit()
    {   
        if (!invul)
        {
            lives--;
            invul = true;
        }
    }
}
