using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathVFX;
  [SerializeField] GameObject hitVFX;


  [Header("Enemy health and score settings")]
  [Tooltip("Total health of enemy.")] [SerializeField] int enemyHealth = 20;
  [Tooltip("Total damage enemy recieves from one hit. Also, the amount of score added per hit.")] [SerializeField] int hitScoreValue = 10;
  [Tooltip("The amount of score points added when the enemy is killed.")] [SerializeField] int killScoreValue = 50;

  ScoreBoard scoreBoard;

  GameObject parentGameObject;

  int currentAmountOfHits;

  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
    parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
  }

  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
  }

  private void ProcessHit()
  {
    GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parentGameObject.transform;
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
    vfx.transform.parent = parentGameObject.transform;
    Destroy(gameObject);
  }
}
