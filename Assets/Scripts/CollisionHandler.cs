using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    ParticleSystem explosionVFX;

    [SerializeField]
    [Tooltip("How long before reloading level on collision death?")]
    float levelLoadDelay = 1f;

    void OnTriggerEnter(Collider trigger)
    {
        Debug.Log(this.name + "** was triggered by **" + trigger.gameObject.name);
        HandleDeathSequence();
    }

    void HandleDeathSequence()
    {
        explosionVFX.Play();
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
