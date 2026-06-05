using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject timesUp;
    public GameObject health;
    public Character player;
    public TextMeshProUGUI Score;
    public GameObject points;
    [SerializeField] float remainingTime;
    // Update is called once per frame
    void Start()
    {
        timesUp.gameObject.SetActive(false);
    }
    void Update()
    {
        if (remainingTime > 0) 
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            timesUp.gameObject.SetActive(true);
            health.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            Score.gameObject.SetActive(true);
            points.SetActive(false);
            Score.text = player.score.ToString();
            player.speed = 0;
        }
        int minutes=Mathf.FloorToInt(remainingTime/60);
        int seconds=Mathf.FloorToInt(remainingTime%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
