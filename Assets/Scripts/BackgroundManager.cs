using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private List<Sprite> backgroundImages;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime;
    
    void Awake()
    {
        background.sprite = backgroundImages[Random.Range(0, backgroundImages.Count)];
        InvokeRepeating("SpawnBackground",0,spawnTime);
        Destroy(background.gameObject,20 * moveSpeed);
    }

    
    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    public void SpawnBackground()
    {
       var insBackground = Instantiate(background.gameObject, spawnPoint.transform);
       
       insBackground.name = "Background";
       insBackground.transform.position = spawnPoint.transform.position;
       
       background = insBackground.GetComponent<Image>();
       spawnPoint = insBackground.transform.GetChild(0);
       
       insBackground.transform.SetParent(transform);
       Destroy(insBackground.gameObject,40 * moveSpeed);
    }
}
