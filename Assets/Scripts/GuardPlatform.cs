using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPlatform : MonoBehaviour {

    float length, startpos;
    public float level;
    
    
    // Start is called before the first frame update
    void Start() {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        float distance = level * Time.deltaTime;
        
        if (transform.position.x <= -length) {
            transform.position = new Vector3(length, transform.position.y, transform.position.z);
        }
        
        transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
    }
}
