using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 1;
    public bool collide = true;
    
    void Start()
    {
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Damaged(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "EnemyLower")
        {
            other.gameObject.GetComponent<EnemyAnim>().mainDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Meteor")
        {
            if (collide)
                Destroy(gameObject);
            else
            {
                other.gameObject.GetComponent<UFO>().Hit();
                Destroy(gameObject);
            }
        }
    }

    public void SetDamage(float pdamage)
    {
        damage = pdamage;
    }

    public void SetTrue()
    {
        collide = false;
    }
}
