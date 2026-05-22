using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class AIBee : MonoBehaviour
{
    [Header("Ai Parameters")]
    
    public float speed = 5f;
    public float scanRadius;
    public int pollen = 0;

    [Space]

    [Header("Ai Information")]

    public GameObject home;
    public string targetTag = "Flower";
    public GameObject target;
    public GameObject closest;
    [Space]
    public List<GameObject> objectsInRange = new List<GameObject>();

    NavMeshAgent agent;

    public bool hasCollectedFlower;


    private void Start()
    {
        hasCollectedFlower = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        GetComponent<CircleCollider2D>().radius = scanRadius;
        CalculateDesire(transform.position);
        if (pollen >= 5)
        {
            target = home;
            if (home.GetComponent<BoxCollider2D>().IsTouching(GetComponent<BoxCollider2D>()))
            {
                pollen = 0;
            }
        }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            pollen += 1;
            Destroy(collision.gameObject);
        }
    }
    void CalculateDesire(Vector2 playerLocation)
    {
        float closestDist = scanRadius;
        if (objectsInRange.Count > 0)
        {
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
        else
        {
            target = home;
        }
    }
}
