using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] platforms;
    // bool stillConnected = true;
    float startPosition = 42.5f;
    
    void Start() {
        foreach (GameObject platform in platforms) {
            Instantiate(platform, RandomSpawnPosition(), Quaternion.identity);
            startPosition += 12.5f;
        }
    }
    
    Vector3 RandomSpawnPosition() {
        return new Vector3(startPosition + Random.Range(0f, 0.2f), Random.Range(-3.5f, -2.0f), 0);
    }
        
    void OnJointBreak2D(Joint2D brokenJoint) {
        Debug.Log("A joint has just been broken!");
        Debug.Log("The broken joint exerted a reaction force of " + brokenJoint.reactionForce);
        // stillConnected = false;
    }
}
