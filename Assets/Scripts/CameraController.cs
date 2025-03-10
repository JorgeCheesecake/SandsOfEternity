

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool clickToMoveCamera = false; 
    public bool canZoom = true;

    public float sensitivity = 5f;
    public Vector2 cameraLimit = new Vector2(-45, 40);

    float mouseX;
    float mouseY;
    float offsetDistanceY;
    public Animator anim;

    Transform player;

    void Start()
{
    player = GameObject.FindWithTag("Player").transform;
    offsetDistanceY = transform.position.y;

    if (!clickToMoveCamera && !anim.GetBool("morir"))
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    if (anim.GetBool("morir"))
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

    void Update()
    {
        transform.position = player.position + new Vector3(0, offsetDistanceY, 0);

        if (canZoom && Input.GetAxis("Mouse ScrollWheel") != 0)
            Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * sensitivity * 2;

        if (clickToMoveCamera)
            if (Input.GetAxisRaw("Fire2") == 0)
                return;

        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;

        mouseY = Mathf.Clamp(mouseY, cameraLimit.x, cameraLimit.y);
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }
}
