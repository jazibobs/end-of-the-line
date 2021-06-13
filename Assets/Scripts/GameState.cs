using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool active;
    public static int difficulty;
    public GameObject resetButton;
    public GameObject menuButton;
    
    void Start()
    {
        active = true;
        difficulty = 1;
        resetButton.SetActive(false);
        menuButton.SetActive(false);
    }
    
    void Update() {
        if (!active) {
            resetButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }
}
