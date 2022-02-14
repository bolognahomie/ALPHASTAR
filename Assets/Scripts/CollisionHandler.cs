using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadLevelDelay = 1f;

  void OnTriggerEnter(Collider other)
  {
    ProcessCrash();
  }

  void ProcessCrash()
  {
    Debug.Log($"{this.name} collided with something 2");
    GetComponent<PlayerControls>().enabled = false;
    Invoke("ReloadLevel", loadLevelDelay);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
