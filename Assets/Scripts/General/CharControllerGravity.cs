using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharControllerGravity : MonoBehaviour
{
    [Header("Variables")]
    public float Radius;
    public LayerMask LayerMask;

    [Header("Unity Set Up")]
    public Transform GroundCheck;
    public Gravity Gravity;

    [Header("Debug")]
    public bool IsJumping = false;
    public float DownVelocity = 0f;

    public bool IsGrounded{
        get { return Physics.CheckSphere(GroundCheck.position, Radius, LayerMask); }
    }

    private CharacterController controller;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        DoGravity();
    }

    private void DoGravity(){
        if(!IsGrounded || IsJumping){
            DownVelocity += Gravity.Rate * Time.deltaTime;
        }else{
            DownVelocity = Gravity.GroundedRate;
        }

        controller.Move(DownVelocity * Time.deltaTime * Vector3.down);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GroundCheck.position, Radius);
    }
}
