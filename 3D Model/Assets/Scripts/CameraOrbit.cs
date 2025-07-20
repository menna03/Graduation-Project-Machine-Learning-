using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Orbit Settings")]
    public float rotationSpeed = 5.0f;
    public float zoomSpeed = 5.0f;
    public float minZoom = 2.0f;
    public float maxZoom = 15.0f;

    [Header("Target Offset")]
    public Vector3 targetOffset = new Vector3(0, 1f, 0); // Adjust to center around waist or feet

    private PlayerControls playerControls;
    private Vector2 lookInput;
    private float zoomInput;
    private bool isClicking;

    private bool isPinching = false;
    private float previousPinchDistance = 0f;

    private float distance = 5.0f;

    private float pitch = 0f; // Vertical rotation
    private float yaw = 0f;   // Horizontal rotation

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Camera.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerControls.Camera.Look.canceled += ctx => lookInput = Vector2.zero;

        playerControls.Camera.Click.performed += ctx => isClicking = true;
        playerControls.Camera.Click.canceled += ctx => isClicking = false;

        playerControls.Camera.Zoom.performed += ctx => zoomInput = ctx.ReadValue<float>();
        playerControls.Camera.Zoom.canceled += ctx => zoomInput = 0f;

        playerControls.Camera.Pinch.started += ctx => StartPinch();
        playerControls.Camera.Pinch.canceled += ctx => EndPinch();
    }

    private void OnEnable() => playerControls.Camera.Enable();
    private void OnDisable() => playerControls.Camera.Disable();

    void Start()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);
        }

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (isPinching)
        {
            HandlePinch();
        }
        else if (isClicking && lookInput.magnitude > 0.01f)
        {
            HandleRotation();
        }

        HandleMouseZoom();

        // Updated camera position with offset
        Vector3 targetPosition = target.position + targetOffset;
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.rotation = rotation;
        transform.position = targetPosition - rotation * Vector3.forward * distance;
    }

    private void HandleRotation()
    {
        yaw += lookInput.x * rotationSpeed * Time.deltaTime;
        pitch -= lookInput.y * rotationSpeed * Time.deltaTime;

        // Clamp pitch to prevent flipping
        pitch = Mathf.Clamp(pitch, -30f, 60f);
    }

    private void HandleMouseZoom()
    {
        if (zoomInput != 0)
        {
            float normalizedZoom = zoomInput > 0 ? 1 : (zoomInput < 0 ? -1 : 0);
            distance = Mathf.Clamp(distance - normalizedZoom * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
        }
    }

    private void StartPinch()
    {
        if (Touchscreen.current.touches.Count < 2) return;

        isPinching = true;
        Vector2 touch0 = Touchscreen.current.touches[0].position.ReadValue();
        Vector2 touch1 = Touchscreen.current.touches[1].position.ReadValue();
        previousPinchDistance = Vector2.Distance(touch0, touch1);
    }

    private void HandlePinch()
    {
        if (Touchscreen.current.touches.Count < 2)
        {
            EndPinch();
            return;
        }

        Vector2 touch0 = Touchscreen.current.touches[0].position.ReadValue();
        Vector2 touch1 = Touchscreen.current.touches[1].position.ReadValue();
        float currentPinchDistance = Vector2.Distance(touch0, touch1);

        float pinchDifference = currentPinchDistance - previousPinchDistance;
        distance = Mathf.Clamp(distance - pinchDifference * zoomSpeed * 0.01f, minZoom, maxZoom);

        previousPinchDistance = currentPinchDistance;
    }

    private void EndPinch()
    {
        isPinching = false;
    }
}
