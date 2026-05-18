using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class AIBee : MonoBehaviour
{
    public GameObject home;
    public float scanRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> objectsInRange = new List<GameObject>();
    public string targetTag = "Flower";
    public GameObject target;
    public GameObject closest;
    public float speed = 5f;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        GetComponent<CircleCollider2D>().radius = scanRadius;
        CalculateDesire(transform.position);
        agent.SetDestination(target.transform.position);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Flower"))
        {
            objectsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        objectsInRange.Remove(other.gameObject);
    }

    void CalculateDesire(Vector2 playerLocation)
    {
        float closestDist = 100;
        foreach(GameObject flower in objectsInRange)
        {
            float objectDistance = Vector2.Distance(playerLocation,flower.transform.position);
            if (objectDistance < closestDist)
            {
                closestDist = objectDistance;
                closest = flower;
            }
        }
        target = closest;
    }
}
