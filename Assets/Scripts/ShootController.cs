using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private List<GameObject> bulletPrefab;
    [SerializeField] private ParticleSystem shootEffect;
    public GameObject bullet;
    
    private void Awake()
    {
        bullet = bulletPrefab[Random.Range(0, bulletPrefab.Count)];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
       GameObject insBullet = Instantiate(bullet, transform.parent);
       insBullet.transform.position = firePoint.position;
       shootEffect.Play();
    }
}
