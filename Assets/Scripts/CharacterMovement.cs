using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public float speed = 0.5f;
    public float turnSpeed = 1.0f;
    float driftFactor = 0.95f;
    private Rigidbody2D Rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        input.Normalize();
        
    }

    void FixedUpdate()
    {
        Rb.AddForce(transform.up * speed, ForceMode2D.Force);

        Vector2 forwardVelocity = transform.up * Vector2.Dot(Rb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(Rb.linearVelocity, transform.right);

        Rb.linearVelocity = forwardVelocity + rightVelocity * driftFactor;

        Rb.rotation -= input.x * turnSpeed;

    }
}
