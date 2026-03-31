using System;
using Unity.Mathematics;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public Sprite[] spritesArray;
    private SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    public float turnSpeed = 2.5f;
    public float turnAmp = 10f;

    float _time;
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
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward,turnSpeed * -input.x);
    }
}
