using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    
    float runningSpeed = 6f;
    float runningDirection;
    bool isGrounded;
    Vector2 movement;

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (GameState.active) {
            isGrounded = GuardOnGround();
            
            if (isGrounded) {
                runningDirection = Mathf.PingPong(Time.time, runningSpeed) - runningSpeed / 2;
                movement = new Vector2(runningDirection, rb.velocity.y);
                rb.velocity = movement;  
            }
        } else {
            animator.SetBool("PlayerDead", true); 
            movement = new Vector2(0, 0);
            rb.velocity = movement;
        }
    }
    
    bool GuardOnGround() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
