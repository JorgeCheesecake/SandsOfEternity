using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private bool isGrounded = false;
    private float horizontalaxis;
    private float verticalaxis;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalaxis = Input.GetAxis("horizontal");
        verticalaxis = Input.GetAxis("vertical");
        Vector3 move = new Vector3(horizontalaxis, 0, verticalaxis);
        rb.velocity = new Vector3(move.x * speed * Time.deltaTime, rb.velocity.y, move.z * speed * Time.deltaTime);

    }
}
