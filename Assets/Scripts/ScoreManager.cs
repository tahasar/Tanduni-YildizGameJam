using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
