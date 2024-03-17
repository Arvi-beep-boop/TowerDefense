using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        Debug.Log("Damage applied!");
    }
}
