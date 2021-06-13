using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public AudioSource sound;
    
    float mx;
    float movementSpeed = 250;
    float jumpForce = 300;
    float distanceToGround;
    bool isGrounded;
    bool isDead;
    Vector2 movement;
    
    // Update is called once per frame
    void FixedUpdate() {
        if (GameState.active) {
            isGrounded = PlayerOnGround();
            if (Input.GetButtonDown("Jump") && isGrounded) {
                Jump();
            }
            
            if (isGrounded) {
                mx = Input.GetAxis("Horizontal");
                animator.SetFloat("Speed", Mathf.Abs(mx));
                
                if (mx < 0) {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    movement = new Vector2(mx * movementSpeed * 1.5f * Time.deltaTime, rb.velocity.y);
                } else {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    movement = new Vector2(mx * movementSpeed * 0.5f * Time.deltaTime, rb.velocity.y);
                }
                
                rb.velocity = movement;
            }
            
            if (transform.position.y < -3.9 || transform.position.x < -10) {
                PlayerGameOver();
            }  
        } 
    }
    
    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
        rb.velocity = movement;
        sound.Play();
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Death") {
            Debug.Log(other.gameObject.name);
            PlayerGameOver();
        }
    }
    
    void PlayerGameOver() {
        GameState.active = false;
        rb.velocity = new Vector2(0,0);
        animator.SetBool("IsDead", true); 
    }
    
    bool PlayerOnGround() {
        bool groundFlag = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("IsGrounded", groundFlag);
        return groundFlag;
    }
}
