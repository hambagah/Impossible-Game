using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public int eSpeed = 5;
    public float direction = 1f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wall())
            Flip();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(direction, 0);
        rb.MovePosition(rb.position + movement * (eSpeed) *  Time.fixedDeltaTime);
    }

    
    private bool Wall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    public void mainDamage (float damage)
    {
        enemyHealth.GetComponent<EnemyHealth>().Damaged(damage);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        //eSpeed *= -1f;
        direction *= -1f;
    }
}
