using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Image player;
    [SerializeField] private List<Sprite> playerImages;
    private GameManager _manager;
    
    void Awake()
    {
        player.sprite = playerImages[Random.Range(0, playerImages.Count)];
        _manager = FindObjectOfType<GameManager>();
        
        player.SetNativeSize();
    }

    private void Update()
    {
        if(_manager.isRespawn) return;

        //if (!Input.GetMouseButton(0)) return;
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            
        transform.position = mousePosition;
    }

}
