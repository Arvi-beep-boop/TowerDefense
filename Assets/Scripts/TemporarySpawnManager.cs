using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPlace;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(enemyPrefab, spawnPlace.position, enemyPrefab.transform.rotation);
    }
}
