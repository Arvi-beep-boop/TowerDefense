using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int money = 0;
    [SerializeField]
    private int health = 100;
    public static LevelManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

        void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void RemoveMoney(int amount) 
    {   if(money < amount)
        {
            Debug.LogError("insufficient funds!");
            return;
        }
        money -= amount;
    }
    public void AddHealth(int amount)
    {
        health += amount;
    }
    public void RemoveHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    // showing how merge works
}
