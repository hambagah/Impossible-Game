using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Player target;
    private Vector2 moveDirection;
    public bool collide = true;

    void Start()
    {
        /*rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);*/
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    public void SetSpeed(float eBulSpeed)
    {
        speed = eBulSpeed;
    }

    public void SetCollide()
    {
        collide = false;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Hit();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Meteor" && collide)
        {
            Destroy(gameObject);
        }
    }
}
