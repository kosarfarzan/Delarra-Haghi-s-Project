using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<Transform> spawnPosition;
    [SerializeField] private float spawnRate,countDown;
    public bool spawn;
    public List<GameObject> spawnedEnemy;
    
    void Start()
    {
        countDown = spawnRate;
    }

    
    void Update()
    {
        if(!spawn) return;
        if (!(countDown > 0)) return;
        
        countDown -= Time.deltaTime;
        if (!(countDown <= 0)) return;
        
        countDown = spawnRate;
        Spawn();

    }

    private void Spawn()
    {
        Transform spawnPos = spawnPosition[Random.Range(0, spawnPosition.Count)];
        GameObject randomModel = enemyList[Random.Range(0, enemyList.Count)];

        spawnedEnemy.Add(Instantiate(randomModel, spawnPos));
    }
}
