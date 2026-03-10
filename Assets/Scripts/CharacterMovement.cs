using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public float speed = 0.5f;
    public float turnSpeed = 1.0f;
    public Transform target;
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
        target.transform.RotateAround(this.gameObject.transform.position, Vector3.forward,input.x*turnSpeed);
        
    }

    void FixedUpdate()
    {
        Vector3 targetDirection = target.position - transform.position;

        Debug.DrawRay(transform.position, targetDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(Vector3.forward,targetDirection);

        Rb.AddForce(transform.up * speed, ForceMode2D.Force);

    }
}
