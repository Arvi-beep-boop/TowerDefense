using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ammo : ScriptableObject
{
    [Range(50, 500)]
    [Tooltip("m/s")]
    public float velocity = 100;

    [Range(50, 500)]
    public float damage = 100;
}
