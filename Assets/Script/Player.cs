using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 3;
    public float speed;
    public float damage = 1f;
    private bool invul = false;
    private float invulTime;
    private float delay;
    public float shootTime;
    public Animator animator;
    public bool trueForm = false;
    
    public Transform bulletLocation;
    public Bullet bulletPrefab;

    [SerializeField] Movement playerMove;
    [SerializeField] Progress progression;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && delay > 0)
        {
            Bullet bullet = Instantiate(bulletPrefab, bulletLocation.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            if (trueForm)
                bullet.SetTrue();
            delay = shootTime;
        }
        else 
            delay += Time.deltaTime;

        
        if (invulTime > 2f)
        {
            invulTime = 0;
            invul = false;
            animator.SetBool("Invul", false);
        }
        else if (invul) 
        {
            invulTime += Time.deltaTime;
            animator.SetBool("Invul", true);
        }

        if (lives <= 0)
        {
            Die();
        }
    }

    public void Hit()
    {   
        if (!invul)
        {
            lives--;
            invul = true;
            progression.GetComponent<Progress>().Add(30);
        }
    }

    public void Die()
    {

    }
}
