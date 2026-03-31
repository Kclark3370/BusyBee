using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public float speed = 0.5f;
    public float turnSpeed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        
        input.Normalize();
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);

        if (Input.GetKey("space"))
        {
            speed = 20;
            turnSpeed = 1.5f;
        }
        else
        {
            turnSpeed = 3.5f;
            speed = 10;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward,turnSpeed * -input.x);
    }
}
