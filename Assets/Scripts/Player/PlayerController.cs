using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    public float Sensitivity = 10f;
    public float Speed = 5f;

    [Header("Unity Set Up")]
    public PlayerInput InputControls;
    public Transform CameraTransform;

    // Input Actions
    private InputAction look;
    private InputAction move;

    private CharacterController controller;
    private float xRotation = 0f;

    private void Awake() {
        InputControls = new PlayerInput();
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        DoLook();
        DoMove();
    }

    private void DoLook(){
        Vector2 deltaLook = look.ReadValue<Vector2>();

        xRotation -= deltaLook.y * Sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        CameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        float yRotation = deltaLook.x * Sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }

    private void DoMove(){
        Vector2 inputVector = move.ReadValue<Vector2>();
        Vector3 moveVector = transform.forward * inputVector.y + transform.right * inputVector.x;
        controller.Move(Speed * Time.deltaTime * moveVector);
    }

    private void OnEnable() {
        look = InputControls.Player.Look;
        look.Enable();

        move = InputControls.Player.Move;
        move.Enable();
    }

    private void OnDisable() {
        look.Disable();
        move.Disable();
    }
}
