using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    Text score;
    float scoreValue;
    float scoreFactor;
    string scoreFormat ="000000";

    void Start()
    {
        scoreValue = 0;
        scoreFactor = 10;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.active) {
            score.text = scoreValue.ToString(scoreFormat);
            scoreValue += scoreFactor * Time.deltaTime;
        }
    }
}
