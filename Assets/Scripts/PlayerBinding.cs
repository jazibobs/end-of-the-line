using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBinding : MonoBehaviour
{
    public GameObject otherPlayer;
    public static float distance;
    
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(this.gameObject.transform.position, otherPlayer.transform.position);
        // Debug.Log("Distance between players: " + distance);
    }
}
