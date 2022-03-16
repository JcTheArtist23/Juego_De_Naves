using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform enemySpawn;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        enemy = PoolingController.instance.GetPoolObject(2);
        enemy.transform.position = enemySpawn.position;
        enemy.SetActive(true); 
    }
}
