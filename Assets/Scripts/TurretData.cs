using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

enum m_targetting
{
    // types of enemiest that will have target priority for turret
    closest, //0
    furthest, //1
    fastest,  //2
    slowest, //3
    first, //4
    last, //5
}
[CreateAssetMenu]
public class TurretData : ScriptableObject
{
    // default stats
    [SerializeField]
    [Tooltip("Turret's damage")]
    [Range(1f, 20f)]
    public float damage;

    [SerializeField]
    [Tooltip("Turret's pierce")]
    [Range(0.1f, 1.0f)]
    public float pierce;

    [SerializeField]
    [Tooltip("Turret's fire rate (seconds)")]
    [Range(0.2f, 2f)]
    public float fireRate;

    [SerializeField]
    [Tooltip("Turret's attack range (meters)")]
    [Range(3f,20f)]
    public float range;

    [SerializeField]
    [Tooltip("Turret's turn (rotation) speed")]
    [Range(1f, 20f)]
    public float turnSpeed;

    [SerializeField]
    [Tooltip("Turret's icon shown in UI")]
    public Sprite icon;

    [SerializeField]
    [Tooltip("Turret's targetting type")]
    m_targetting targettingType ;

    // stats updated during gameplay
  /*  uint damage_dealt;
    GameObject[] equiped_items;*/
}
