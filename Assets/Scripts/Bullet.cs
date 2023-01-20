using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float forceValue;
    
    void Awake() { Destroy(gameObject,2); }

    private void Update()
    {
        transform.position += Vector3.up * forceValue * Time.deltaTime;
    }
}
