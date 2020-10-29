using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addiing : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    
    public void updateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
