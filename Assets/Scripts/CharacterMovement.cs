using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public float speed = 10f;
    public float sprintSpeed = 20f;
    public float stamina = 100f;
    public float staminaDrainRate = 25f;
    public float staminaGainRate = 20f;
    public float maxStamina = 100f;
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

        if (Input.GetKey("space") && stamina >= 0)
        {
            speed = 20;
            turnSpeed = 1.5f;
            stamina -= staminaDrainRate * Time.deltaTime;
            
        }
        if (stamina < maxStamina)
        {
            stamina += staminaGainRate * Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina,0,maxStamina);
        turnSpeed = 3.5f;
        speed = 10;
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward,turnSpeed * -input.x);
    }
}
