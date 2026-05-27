using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal.Filters;
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
    public GameObject searchLocation;
    [Space]
    public List<GameObject> objectsInRange = new List<GameObject>();

    NavMeshAgent agent;

    public bool isSearching;


    private void Start()
    {
        isSearching = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        GetComponent<CircleCollider2D>().radius = scanRadius;
        CalculateDesire(transform.position);
        agent.SetDestination(target.transform.position);
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
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

    Vector3 GetRandomNavMeshPoint(Vector3 center, float range)
{
    for (int i = 0; i < 30; i++) // try multiple times
    {
        Vector3 randomPoint = center + new Vector3(
            Random.Range(-range, range),
            Random.Range(-range, range),
            0f
        );

        NavMeshHit hit;

        // Check if point is on NavMesh
        if (NavMesh.SamplePosition(randomPoint, out hit, 5f, NavMesh.AllAreas))
        {
            return hit.position;
        }
    }

    // fallback if nothing found
    return center;
}

    void CalculateDesire(Vector2 playerLocation)
    {

        if (pollen >= 5)
        {
            target = home;
            if (home.GetComponent<BoxCollider2D>().IsTouching(GetComponent<BoxCollider2D>()))
            {
                pollen = 0;
                isSearching = false;
            }
        }

        float closestDist = scanRadius;
        if (objectsInRange.Count > 0)
        {
            isSearching = false;
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
        if (objectsInRange.Count <= 0 && isSearching == false)
        {
            isSearching=true;
            searchLocation.transform.position = GetRandomNavMeshPoint(playerLocation, 100f);
            target = searchLocation;
            agent.SetDestination(target.transform.position);
        }
        if (Vector2.Distance(transform.position,searchLocation.transform.position) < 1f)
            {
                searchLocation.transform.position = GetRandomNavMeshPoint(playerLocation, 100f);
            }
        }
    }


