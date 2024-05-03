using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // will be changed as Scriptable Obj in the future
    public float health = 20;
    public float maxHealth = 20;
    public int damage = 20;
    public int moneyValue = 2; // Value in money for killing this enemy
    private GameObject projectileParent = null;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image healthBarBackGround;
    
    // takes damage amount and source turret (one that shot) to let it know if the enemy is destroyed.
    public void ApplyDamage(int damage) 
    {
        healthBar.enabled = true;
        healthBarBackGround.enabled = true;
        health -= damage;
        Debug.Log("Damage applied!");
        if (health <= 0)
        {
            LevelManager.instance.AddMoney(moneyValue);
            Destroy(gameObject, 0.1f);
            projectileParent.SendMessage("EnemyDestroyed", SendMessageOptions.DontRequireReceiver);
        }
        projectileParent = null;
    }
    public void SetProjectileParent(GameObject parent)
    {
        projectileParent = parent;
    }
    private void Start()
    {
        maxHealth = health;
        healthBar.enabled = false;
        healthBarBackGround.enabled = false;
    }
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;   
    }

}
