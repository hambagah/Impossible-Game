using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Animator animator;
    private float horizontal, vertical;
    public float speed = 10f;
    public float acceleration = 4f;
    public float decceleration = 3f;
    public float velPower = 1.1f;
    
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        vertical = (Input.GetKey(KeyCode.S) ? -1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);
        animator.SetFloat("Speed", horizontal);
    }

    private void FixedUpdate()
    {
        /*float targetSpeedX = horizontal * speed;
        float speedDiffX = targetSpeedX - rb.velocity.x;
        float accelRateX = (Mathf.Abs(targetSpeedX) > 0.01f) ? acceleration : decceleration;
        float movementX = Mathf.Pow(Mathf.Abs(speedDiffX) * accelRateX, velPower) * Mathf.Sign(speedDiffX);

        float targetSpeedY = vertical * speed;
        float speedDiffY = targetSpeedY - rb.velocity.y;
        float accelRateY = (Mathf.Abs(targetSpeedY) > 0.01f) ? acceleration : decceleration;
        float movementY = Mathf.Pow(Mathf.Abs(speedDiffY) * accelRateY, velPower) * Mathf.Sign(speedDiffY);
*/      
        Vector2 movement = new Vector2(horizontal, vertical);
        //rb.AddForce(speed *  Vector2.right);
        //rb.AddForce(speed *  Vector2.up);
        rb.MovePosition(rb.position + movement * (speed) *  Time.fixedDeltaTime);
    }
}
