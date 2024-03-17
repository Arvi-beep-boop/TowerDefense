using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public class TurretData : ScriptableObject
{
    // default stats
    public uint damage;
    public uint pierce;
    public float fire_rate;
    public float range;
    public float turn_speed;

    // stats updated during gameplay
    uint damage_dealt;
    GameObject[] equiped_items;
}
