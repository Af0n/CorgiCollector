using UnityEngine;

[CreateAssetMenu(fileName = "Gravity", menuName = "Scriptable Objects/Gravity")]
public class Gravity : ScriptableObject
{
    public float Rate = Physics.gravity.magnitude;
    public float GroundedRate;
}
