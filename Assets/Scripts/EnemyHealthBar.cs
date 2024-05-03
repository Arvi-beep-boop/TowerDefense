using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public Image healthBarBackGround;
    [SerializeField] private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy.maxHealth = enemy.health;
        healthBar.enabled = false;
        healthBarBackGround.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = enemy.health / enemy.maxHealth;
    }
}
