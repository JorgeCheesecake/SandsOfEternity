using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{
    public float velocity = 1f;
    public float sprintAdittion = 3.5f;
    public float jumpForce = 9f;
    public float jumpTime = 0.85f;
    public float gravity = 9.8f;

    float jumpElapsedTime = 0;
    public Animator ani;

    bool isJumping = false;
    bool isSprinting = false;
    bool isCrouching = false;
    public GameObject espada;

    float inputHorizontal;
    float inputVertical;
    bool inputJump;
    bool inputCrouch;
    bool inputSprint;

    public Slider Barravida;

    Animator animator;
    CharacterController cc;

    private float groundDetectionDelay = 0.1f; // retardo de 0.1 segundos
    private float lastGroundDetectionTime = 0f;

    bool morir = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogWarning("Hey buddy, you don't have the Animator component in your player. Without it, the animations won't work.");
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("arma"))
        {
            Barravida.value -= 25;
        }
    }

    void Update()
    {
        if (!morir)
        {
            inputHorizontal = Input.GetAxis("Horizontal");
            inputVertical = Input.GetAxis("Vertical");
            inputJump = Input.GetAxis("Jump") == 1f;
            inputSprint = Input.GetKey(KeyCode.LeftShift);

            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.JoystickButton1))
                isCrouching = true;
            else
            {
                isCrouching = false;
            }

            if (inputSprint)
                isSprinting = true;
            else
            {
                isSprinting = false;
            }

            if (Time.time - lastGroundDetectionTime >= groundDetectionDelay)
            {
                lastGroundDetectionTime = Time.time;

                if (cc.isGrounded && animator != null)
                {
                    animator.SetBool("crouch", isCrouching);
                    animator.SetBool("run", isSprinting);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("attack", true);
            }
            else
            {
                animator.SetBool("attack", false);
            }

            if (inputHorizontal != 0 || inputVertical != 0)
            {
                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }

            if (inputJump)
            {
                isJumping = true;
                animator.SetBool("air", true);
            }
            else if (cc.isGrounded)
            {
                animator.SetBool("air", false);
            }

            HeadHittingDetect();

            if (Input.GetKeyDown(KeyCode.E))
            {
                espada.SetActive(true);
                animator.SetBool("arma", true);
            }
            else
            {
                espada.SetActive(false);
            }

            if (Barravida.value < 0)
            {
                Barravida.value = 0;
            }

            if (Barravida.value == 0)
            {
                ani.SetBool("morir", true);
                morir = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!morir)
        {
            float velocityAdittion = 0;
            if (isSprinting == true)
                velocity = 5f;
            else if (isSprinting == false)
                velocity = 3f;

            if (isCrouching == true)
                velocity = 1f;
            else if (isCrouching == false)
            {
                velocity = 3f;
            }

            if (isSprinting == true && isCrouching == true)
            {
                velocity = 2f;
            }
            else if (isSprinting == false && isCrouching == true)
            {
                velocity = 1f;
            }
            else if (isSprinting == true && isCrouching == false)
            {
                velocity = 5f;
            }

            float directionX = inputHorizontal * (velocity + velocityAdittion) * Time.deltaTime;
            float directionZ = inputVertical * (velocity + velocityAdittion) * Time.deltaTime;
            float directionY = 0;

            if (isJumping)
            {
                directionY = Mathf.SmoothStep(jumpForce, jumpForce * 0.30f, jumpElapsedTime / jumpTime) * Time.deltaTime;

                jumpElapsedTime += Time.deltaTime;
                if (jumpElapsedTime >= jumpTime)
                {
                    isJumping = false;
                    jumpElapsedTime = 0;
                }
            }

            directionY = directionY - gravity * Time.deltaTime;

            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            forward = forward * directionZ;
            right = right * directionX;

            if (directionX != 0 || directionZ != 0)
            {
                float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }

            Vector3 verticalDirection = Vector3.up * directionY;
            Vector3 horizontalDirection = forward + right;

            Vector3 moviment = verticalDirection + horizontalDirection;
            cc.Move(moviment);

            if (Input.GetKey(KeyCode.E))
            {
                ani.SetBool("arma", true);
            }
        }
    }

    void HeadHittingDetect()
    {
        float headHitDistance = 1.1f;
        Vector3 ccCenter = transform.TransformPoint(cc.center);
        float hitCalc = cc.height / 2f * headHitDistance;

        if (Physics.Raycast(ccCenter, Vector3.up, hitCalc))
        {
            jumpElapsedTime = 0;
            isJumping = false;
        }
    }
}