using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    private GameManager _manager;
    private EnemySpawner _enemySpawner;
    
    private bool isDie;
    
    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        
        Destroy(gameObject,5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Bullet") && !other.collider.CompareTag("Player")) return;
        
        isDie = true;
        
        if(!other.collider.CompareTag("Player"))
            Destroy(other.gameObject);
        else
            _manager.ReSpawnPlayer();
        
        _manager.AddScore();
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        Instantiate(effect, transform).transform.parent = transform.parent;
        _enemySpawner.spawnedEnemy.Remove(gameObject);
        
        if (!isDie)
            _manager.Damage();
    }
}
