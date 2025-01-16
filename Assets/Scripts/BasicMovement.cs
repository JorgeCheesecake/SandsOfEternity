using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public CharacterController character;
    public float turnsmoothtime = 0.1f;
    float turnsmoothvelocity;
    public Transform cam;
    public float jumpSpeed = 5.0f;
    public float gravity = 9.81f;
    private Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }


        float horizontalinput = Input.GetAxisRaw("Horizontal");
        float verticalinput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalinput, 0f, verticalinput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnsmoothtime);

            Vector3 movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            character.Move(movedir * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
            isJumping = true;
        }

        if (isJumping)
        {
            moveDirection.y -= gravity * Time.deltaTime;

           //if (IsGrounded())
           //{
           //    isJumping = false;
           //    moveDirection.y = 0f;
           //}
        }

        character.Move(moveDirection * Time.deltaTime);
    }

//    bool IsGrounded()
//{
//    float rayDistance = 0.5f;
//
//    Vector3 rayDirection = Vector3.down;
//
//    RaycastHit hit;
//    if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
//    {
//        // Verifica si el rayo golpeó el suelo
//        if (hit.distance < rayDistance)
//        {
//            return true;
//        }
//    }
//
//    return false;
//}
}