using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AIBee : MonoBehaviour
{
    public GameObject home;
    public float scanRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> objectsInRange = new List<GameObject>();
    public string targetTag = "Flower";
    public GameObject target;

    void Update()
    {
        
        GetComponent<CircleCollider2D>().radius = scanRadius;
        CalculateDesire(transform.position);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(targetTag)) {
            objectsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(targetTag)) {
            objectsInRange.Remove(other.gameObject);
        }
    }

    void CalculateDesire(Vector2 playerLocation)
    {
        foreach(GameObject flower in objectsInRange)
        {
            float Flowerdistance = Vector2.Distance(playerLocation, flower.transform.position);
        }
        
    }
}
