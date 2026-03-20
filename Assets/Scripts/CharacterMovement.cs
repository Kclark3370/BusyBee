using Unity.Mathematics;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 input;
    public float speed = 0.5f;
    public float turnSpeed = 2.5f;
    public float turnAmp = 10f;
    public GameObject model;
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
        model.transform.Rotate(Vector3.forward,turnSpeed*turnAmp* input.x);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward,turnSpeed * -input.x);

        RotateModel();
    }

    void RotateModel()
    {
        if (input.x > 0 & model.transform.rotation.z < 20)
        {
            model.transform.Rotate(Vector3.forward,turnSpeed*turnAmp* input.x);
        }
        if (input.x == 0)
        {
            model.transform.rotation = Quaternion.Euler(model.transform.rotation.x,0,0);
        }
    }
}
