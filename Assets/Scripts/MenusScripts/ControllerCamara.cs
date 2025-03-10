using UnityEngine;

public class ControllerCamara : MonoBehaviour
{
    public bool clickToMoveCamera = false;
    public bool canZoom = true;
    public float sensitivity = 5f;
    public Vector2 cameraLimit = new Vector2(-45, 40);

    public float cameraDistance = 5f;
    public float collisionOffset = 0.2f;
    public LayerMask collisionMask;

    float mouseX;
    float mouseY;
    float offsetDistanceY;

    Transform player;
    public static bool isMenuOpen = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        offsetDistanceY = 2f; 
        LockCursor(true);
    }

    void Update()
    {
        if (isMenuOpen) return;

        if (canZoom && Input.GetAxis("Mouse ScrollWheel") != 0)
            Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * sensitivity * 2;

        if (clickToMoveCamera && Input.GetAxisRaw("Fire2") == 0)
            return;

        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, cameraLimit.x, cameraLimit.y);

        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);

        //Collisiones de la camara NOTOCAR
        Vector3 pivot = player.position + Vector3.up * offsetDistanceY;
        Vector3 direction = (transform.rotation * new Vector3(0, 0, -1)).normalized;
        Vector3 desiredPosition = pivot + direction * cameraDistance;

        if (Physics.Raycast(pivot, direction, out RaycastHit hit, cameraDistance, collisionMask))
        {
            transform.position = pivot + direction * (hit.distance - collisionOffset);
        }
        else
        {
            transform.position = desiredPosition;
        }
    }

    public static void LockCursor(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isMenuOpen = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isMenuOpen = true;
        }
    }
}
