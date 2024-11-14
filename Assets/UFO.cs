using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float uSpeed = 5;
    public float direction = 1f;
    public bool active;
    [SerializeField] GameObject detector;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(detector.transform.position.x) > 15)
            Flip();
            //Destroy();
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

    }
}
