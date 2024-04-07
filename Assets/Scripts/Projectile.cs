using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Ammo Ammo;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Physics.Raycast(new Ray(transform.position, transform.forward * (-1)), out RaycastHit hit, Ammo.velocity * Time.deltaTime))
        {
            transform.position = hit.point;
            hit.collider.SendMessage("SetProjectileParent", this.transform.parent.gameObject, SendMessageOptions.DontRequireReceiver);
            hit.collider.SendMessage("ApplyDamage", Ammo.damage, SendMessageOptions.DontRequireReceiver);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 1f);
            Destroy(this);
        }
        else
        {
            transform.Translate(Vector3.forward * (-1) * Ammo.velocity * Time.deltaTime);
        }
    }
}
