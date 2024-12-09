using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float Speed;
    public float Sensitivity;
    public float JumpHeight;
    public float JumpCooldown;
}
