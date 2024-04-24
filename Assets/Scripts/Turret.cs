using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Ammo ammo;
    [SerializeField] TurretData data;

    private string enemyTag = "Enemy";
    public Transform target; // target to shoot at
    bool shooting = false;
    public bool canShooting = false;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;
        // LookRotation
        if (target != null && canShooting == true)
        {
            RotateTurret(target);
            if (!shooting)
            {
                InvokeRepeating("Fire", data.fireRate, data.fireRate);
                shooting = true;
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, data.range);
    }

    void UpdateTarget() // reload an array of enemies at an interval of X s, keep track of enemies in scene
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // make sure all enemies have this tag
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distance;
            }
        }
        if (shortestDistance <= data.range && nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void RotateTurret(Transform target)
    {
        Vector3 direction = transform.position - target.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * data.turnSpeed).eulerAngles;
        //Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }

    void Fire()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, this.gameObject.transform);
        projectile.GetComponent<Projectile>().Ammo = ammo;
        projectile.transform.parent = null;
    }

    public void EnemyDestroyed()
    {
        target = null;
        shooting = false;
        CancelInvoke("Fire");
    }
}
