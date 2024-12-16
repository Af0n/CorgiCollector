using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharControllerJump))]

public class PlayerController : MonoBehaviour
{
    [Header("Unity Set Up")]
    public PlayerStats stats;
    public PlayerInput InputControls;
    public Transform CameraTransform;

    // Input Actions
    private InputAction look;
    private InputAction move;
    private InputAction jump;
    private InputAction attack;

    private CharacterController controller;
    private CharControllerJump jumper;
    private CharControllerGravity gravity;
    private float xRotation = 0f;

    private void Awake() {
        InputControls = new PlayerInput();

        controller = GetComponent<CharacterController>();
        jumper = GetComponent<CharControllerJump>();
        gravity = GetComponent<CharControllerGravity>();

         Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        DoLook();
        DoMove();

        // do not continue if not grounded
        if(!gravity.IsGrounded){
            return;
        }

        if(jump.triggered){
            DoJump();
        }
    }

    private void DoLook(){
        Vector2 deltaLook = look.ReadValue<Vector2>();

        xRotation -= deltaLook.y * stats.Sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        CameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        float yRotation = deltaLook.x * stats.Sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }

    private void DoMove(){
        Vector2 inputVector = move.ReadValue<Vector2>();
        Vector3 moveVector = transform.forward * inputVector.y + transform.right * inputVector.x;
        controller.Move(stats.Speed * Time.deltaTime * moveVector);
    }

    private void DoJump(){
        jumper.DoJump(stats.JumpHeight, stats.JumpCooldown);
    }

    private void OnEnable() {
        look = InputControls.Player.Look;
        look.Enable();

        move = InputControls.Player.Move;
        move.Enable();

        jump = InputControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable() {
        look.Disable();
        move.Disable();
        jump.Disable();
    }
}
