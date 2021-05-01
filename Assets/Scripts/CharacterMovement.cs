using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement characterMovement;
    private Vector3 movementUpdate;    
    public float moveSpeed;
    private Rigidbody rigidbody3d;

    private void Awake()
    {
        characterMovement = this;
    }

    private void Start()
    {
        rigidbody3d = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementUpdate.x = Input.GetAxis("Horizontal");
        movementUpdate.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody3d.MovePosition(rigidbody3d.position + movementUpdate * moveSpeed * Time.fixedDeltaTime);
    }
}