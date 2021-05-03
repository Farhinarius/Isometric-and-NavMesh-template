using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public static CharMovement instance;
    public float moveSpeed;
    float hrInput, vrInput;
    Vector3 forwardAxis, rightAxis;
    Vector3 movementStep;
    Vector3 direction;
    Vector3 heading;

    private Rigidbody rigidbody3d;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rigidbody3d = GetComponent<Rigidbody>();

        forwardAxis = Camera.main.transform.forward;
        forwardAxis.y = 0;
        forwardAxis = Vector3.Normalize(forwardAxis);

        rightAxis = Camera.main.transform.right;
        rightAxis.y = 0;
        rightAxis = Vector3.Normalize(rightAxis);
    }

    // Update is called once per frame
    void Update()
    {
        hrInput = Input.GetAxis("Horizontal");
        vrInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
            Move();
    }

    private void Move()
    {
        Vector3 rightMov = rightAxis * hrInput * moveSpeed * Time.fixedDeltaTime;
        Vector3 forwardMov = forwardAxis * vrInput * moveSpeed * Time.fixedDeltaTime;

        var heading = Vector3.Normalize(rightMov + forwardMov);

        transform.forward = heading;
        transform.position += rightMov;
        transform.position += forwardMov;
    }
}
