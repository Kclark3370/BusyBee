using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;
public class HealthBarScript : MonoBehaviour
{

    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;  
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public int maxHealth;
    public int currHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString();
        healthBarSlider.value = currHealth;

        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);

        if (currHealth == 0) {
            Application.Quit();
            Debug.Log("Game Over");

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == enemy1)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy2)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy3)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy4)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy5)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy6)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }
        if (other.gameObject == enemy7)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }

    }
}
