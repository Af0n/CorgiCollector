using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharControllerGravity))]

public class CharControllerJump : MonoBehaviour
{
    [Header("Unity Set Up")]
    public Gravity Gravity;

    private CharControllerGravity controller;
    private IEnumerator jumpDelayCoroutine;

    private void Awake() {
        controller = GetComponent<CharControllerGravity>();
    }

    // assumes jump is able to be performed
    public void DoJump(float jumpHeight, float jumpDelay){
        Debug.Log($"{name} jumped! Height{jumpHeight}, Down Velocity {Mathf.Sqrt(jumpHeight * 2f * Gravity.Rate)}");
        jumpDelayCoroutine = JumpWithCooldown(jumpHeight, jumpDelay);
        StartCoroutine(jumpDelayCoroutine);
        
    }

    private IEnumerator JumpWithCooldown(float jumpHeight, float time){
        controller.DownVelocity = -1f * Mathf.Sqrt(jumpHeight * 2f * Gravity.Rate);
        controller.IsJumping = true;
        yield return new WaitForSeconds(time);
        controller.IsJumping = false;
    }
}
