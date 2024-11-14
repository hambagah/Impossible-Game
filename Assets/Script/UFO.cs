using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float uSpeed = 5;
    public float direction = 1f;
    public bool active;
    public int type = 0;
    public Animator animator;
    [SerializeField] GameObject detector;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyHealth enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(detector.transform.position.x) > 15)
        {
            //Flip();
            if (active)
                Check();
            else
                Destroy();
        }

        animator.SetInteger("Type", type);

        if (active)
            animator.SetBool("Active", true);
        else 
            animator.SetBool("Active", false);
    }
    
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(direction, 0);
        rb.MovePosition(rb.position + movement * (uSpeed) *  Time.fixedDeltaTime);
    }
    
    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        uSpeed = Random.Range(1f, 10f);
        direction *= -1f;
        //transform.position = new Vector3(transform.position.x, Random.Range(-1.5f, 1), transform.position.z);
    }

    public void Check()
    {
        if (type == 1)
        {
            enemy.Damaged(400);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetSpeed(float genSpeed)
    {
        uSpeed = genSpeed;
    }

    public void Hit()
    {
        active = !active;
    }
}
