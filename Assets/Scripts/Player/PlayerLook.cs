using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("Variables")]
    public float Sensitivity = 10f;

    [Header("Unity Set Up")]
    public PlayerInput InputControls;
    public Transform CameraTransform;

    private InputAction look;
    private float xRotation = 0f;

    private void Awake() {
        InputControls = new PlayerInput();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Vector2 deltaLook = look.ReadValue<Vector2>();

        xRotation -= deltaLook.y * Sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        CameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        float yRotation = deltaLook.x * Sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }

    private void OnEnable() {
        look = InputControls.Player.Look;
        look.Enable();
    }

    private void OnDisable() {
        look.Disable();
    }
}
