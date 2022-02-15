using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadLevelDelay = 1f;
  [SerializeField] ParticleSystem crashParticles;

//   void Start()
//   {
//     Debug.Log(gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
//   }

  void OnTriggerEnter(Collider other)
  {
    ProcessCrash();
  }

  void ProcessCrash()
  {
    destroyPlane();
    GetComponent<PlayerControls>().enabled = false;
    Invoke("ReloadLevel", loadLevelDelay);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void destroyPlane()
  {
    crashParticles.Play();
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;

    gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
    
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    gameObject.transform.GetChild(0).gameObject.transform.GetChild(6).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
  }
}
