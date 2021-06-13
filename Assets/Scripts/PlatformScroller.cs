using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroller : MonoBehaviour
{   
    float platformDistance;
    
    Rigidbody2D rb;
    float movementSpeed;
    float startingSpeed;
    Vector3 movement;
    int platformCount;
    
    void Start() {
        startingSpeed = 150f;
        platformDistance = 12.5f;
        rb = GetComponent<Rigidbody2D>();
        platformCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.active) {
            movementSpeed = startingSpeed + (GameState.difficulty * 5);
            movement = new Vector2(movementSpeed * Time.deltaTime, rb.velocity.y);
            rb.velocity = -movement;
            
            if (transform.position.x <= -platformDistance * 2 && gameObject.tag != "Starter") {
                transform.position = RandomSpawnPosition();
            } else if (transform.position.x <= -platformDistance * 3) {
                Destroy(gameObject); // Destroy the starting platform
            }
        } else {
            movement = new Vector2(0,0);
            rb.velocity = movement;
        }
        
    }
    
    
    
    Vector3 RandomSpawnPosition() {
        platformCount += 1;
        
        if (platformCount % 2 == 0) {
            GameState.difficulty += 6;
        } 
        
        return new Vector3(platformDistance * 2, Random.Range(-4.0f, -1.75f), 0);
    }
}
