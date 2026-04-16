using UnityEngine;
using TMPro;

public class ScoreItem : MonoBehaviour
{
    public GameObject player;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Update()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject == player)
        {
            Debug.Log("player collided");
            score+=1;
        }
    }
}
