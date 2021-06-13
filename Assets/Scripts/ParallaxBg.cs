using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBg : MonoBehaviour {

    public float level;
    
    float length;
    
    
    // Start is called before the first frame update
    void Start() {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        if (GameState.active) {
            float distance = level * Time.deltaTime;
        
            if (transform.position.x <= -length) {
                transform.position = new Vector3(length, transform.position.y, transform.position.z);
            }
            
            transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
        }
    }
}
