using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public float repeatRate = 2.0f;
    public float startDelay = 1.0f;

    int score = 0;
    int highscore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        InvokeRepeating(nameof(ScoreIncrease), startDelay, repeatRate);
    }

    void ScoreIncrease()
    {
        score = score + 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
