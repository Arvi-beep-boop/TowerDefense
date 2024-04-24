using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Ammo Ammo;
    public float velocity;
    public float damage;
    void Start()
    {
        velocity = Ammo.velocity;
        damage = Ammo.damage;
    }

    
    void Update()
    {
        if(Physics.Raycast(new Ray(transform.position, transform.forward * (-1)), out RaycastHit hit, velocity * Time.deltaTime))
        {
            transform.position = hit.point;
            hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 1f);
            Destroy(this);
        }
        else
        {
            transform.Translate(Vector3.forward * (-1) * velocity * Time.deltaTime);
            Destroy(gameObject, 10f);
        }
    }
}
