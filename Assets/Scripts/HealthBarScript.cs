using UnityEngine;
using UnityEngine.UI;
using TMPro;
<<<<<<< Updated upstream
=======
using UnityEditor;

>>>>>>> Stashed changes
using Unity.VisualScripting;
public class HealthBarScript : MonoBehaviour
{

    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;
    public GameObject player;
    public GameObject enemy1;
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
<<<<<<< Updated upstream
=======

        if (currHealth == 0)
        {
            EditorApplication.isPlaying = false;
            Debug.Log("Game Over");
        }


>>>>>>> Stashed changes
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == enemy1)
        {
            Debug.Log("Damage");
            currHealth = currHealth - 10;
        }

    }
}
