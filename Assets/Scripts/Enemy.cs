using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathVFX;
  [SerializeField] GameObject hitVFX;
  [SerializeField] Transform parent;

  [Header("Enemy health and score settings")]
  [Tooltip("Total health of enemy.")] [SerializeField] int enemyHealth = 20;
  [Tooltip("Total damage enemy recieves from one hit. Also, the amount of score added per hit.")] [SerializeField] int hitScoreValue = 10;
  [Tooltip("The amount of score points added when the enemy is killed.")] [SerializeField] int killScoreValue = 50;

  ScoreBoard scoreBoard;

  int currentAmountOfHits;

  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
  }

  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
  }

  private void ProcessHit()
  {
    GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parent;
    enemyHealth = enemyHealth - hitScoreValue;
    if (enemyHealth <= hitScoreValue)
    {
      // Destroy enemy
      scoreBoard.IncreaseScore(hitScoreValue + killScoreValue);
      DestroyEnemy();
    }
    else
    {
      // Register one hit
      currentAmountOfHits++;
      scoreBoard.IncreaseScore(hitScoreValue);
    }

  }

  private void DestroyEnemy()
  {
    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parent;
    Destroy(gameObject);
  }
}
