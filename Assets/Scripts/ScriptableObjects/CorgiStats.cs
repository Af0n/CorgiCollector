using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "CorgiStats", menuName = "Scriptable Objects/CorgiStats")]
public class CorgiStats : ScriptableObject
{
    [Header("Texts")]
    [TextArea]
    public string title;
    [TextArea]
    public string description;
    [TextArea]
    public string flavorText;

    [Header("Common Stats")]
    public float baseDMG;
    [Tooltip("Time in seconds between barks.")]
    public float fireRate;
    [Tooltip("Time in seconds")]
    public float reloadTime;
    public bool isHitscan;

    [Header("Hitscan")]
    public float maxRange;
    public float falloffRangeMin;
    public float falloutRangeMax;
    [Tooltip("Percent of base damage done at max falloff")]
    public float falloffDamageReduction;

    [Header("Projectile")]
    [Tooltip("Radius around bullet")]
    public float projectileSize;
    public float launchSpeed;
    [Tooltip("per second per second")]
    public float projectileGravity;
    public float projectileLifetime;

    [Header("Unity Set Up")]
    public GameObject bullet;
}
