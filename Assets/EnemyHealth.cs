using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private int currHealth;
    public int distance;
    public int eSpeed = 5;

    public float eShootTime = 3f;
    private float eDelay;
    public float eBulletSpeed = 5f;

    public float eSpreadTime = 10f;
    private float eDelaySpread;
    public int bulletCount;
    public int endAngle;
    public int startAngle;
    public float eSpreadSpeed = 3f;

    public float direction = 1f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
    Player target;
    public eBullet ebullet;
    
    void Start()
    {
        currHealth = health;
        target = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (Wall())
            Flip();

        if (eDelay > eShootTime)
        {    
            Attack();
            eDelay = 0;
        }
        else
            eDelay += Time.deltaTime;

        if (eDelaySpread > eSpreadTime)
        {    
            SpreadAttack();
            eDelaySpread = 0;
        }
        else
            eDelaySpread += Time.deltaTime;
    }

    private void Attack()
    {
        Vector3 bulVector = new Vector3(target.transform.position.x, target.transform.position.y, 0f);
        Vector2 bulDir = (bulVector - transform.position).normalized;
        eBullet bul = Instantiate(ebullet, transform.position, transform.rotation);
        bul.GetComponent<eBullet>().SetMoveDirection(bulDir);
        bul.GetComponent<eBullet>().SetSpeed(eBulletSpeed);
    }

    private void SpreadAttack()
    {
        float angleStep = (endAngle - startAngle)/bulletCount;
        float angle = startAngle;

        for (int i = 0; i < bulletCount+1; i++)
        {
            float dirX = transform.position.x + Mathf.Sin((angle * Mathf.PI)/180f);
            float dirY = transform.position.y + Mathf.Cos((angle * Mathf.PI)/180f);        
            Vector3 bulVector = new Vector3(dirX, dirY, 0f);
            Vector2 bulDir = (bulVector - transform.position).normalized;
            eBullet bul = Instantiate(ebullet, transform.position, transform.rotation);
            bul.GetComponent<eBullet>().SetMoveDirection(bulDir);
            bul.GetComponent<eBullet>().SetSpeed(eSpreadSpeed);

            angle += angleStep;
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(direction, 0);
        rb.MovePosition(rb.position + movement * (eSpeed) *  Time.fixedDeltaTime);
    }

    public void Damaged (int damage)
    {
        currHealth -= damage;
    }

    private bool Wall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
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
