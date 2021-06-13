using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject background;
    float backgroundDirection;
    
    public void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            backgroundDirection = Mathf.PingPong(Time.time, 10);
            background.GetComponent<RectTransform>().transform.Translate((5 - backgroundDirection) / 20, 0, 0);
        }
    }
    
    public void MainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
