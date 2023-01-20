using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI currentScoreText, topScoreText;
   [SerializeField] private CanvasGroup currentCanvas, topCanvas;
   [SerializeField] private Image damageFlasher;
   [SerializeField] private Transform player,reSpawnPos;
   private EnemySpawner _enemySpawner;
   
   public bool isRespawn;
   
   private int topScore, CurrentScore;

   private void Awake()
   {
      _enemySpawner = FindObjectOfType<EnemySpawner>();
      topScore = PlayerPrefs.GetInt("TopScore", 0);
   }

   public void AddScore()
   {
      CurrentScore++;
      currentScoreText.text = "Score : " + CurrentScore;

      if (CurrentScore < topScore)
      {
         currentCanvas.DOFade(1, 0);
         currentCanvas.DOFade(0, 2);
      }
      
      if (CurrentScore <= topScore) return;
      
      topScore = CurrentScore;
      topScoreText.text = "Top : " + topScore;
         
      topCanvas.DOFade(1, 0);
      topCanvas.DOFade(0, 2);
      
      PlayerPrefs.SetInt("TopScore", topScore);
   }

   public void Damage()
   {
      damageFlasher.DOFade(.4f, 0);
      damageFlasher.DOFade(0, 1);
   }

   public void ReSpawnPlayer()
   {

      foreach (var t in _enemySpawner.spawnedEnemy)
         Destroy(t.gameObject);

      _enemySpawner.spawnedEnemy.Clear();
      
      Damage();
      StartCoroutine(nameof(ReSpawn));
   }

   IEnumerator ReSpawn()
   {
      CurrentScore = 0;
      isRespawn = true;
      _enemySpawner.spawn = false;
      player.DOMove(Vector3.down * 10, 0);
      yield return new WaitForSeconds(1f);
      yield return player.DOMove(reSpawnPos.position, 2).WaitForCompletion();
      isRespawn = false;
      _enemySpawner.spawn = true;
   }
}
