using UnityEngine;
using TMPro;

public class ScoreItem : MonoBehaviour
{
    public Character player;

    public TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = player.score.ToString() + " Pollen Collected";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player collided");
            player.score+=1;
            Destroy(this);
        }
    }
}
