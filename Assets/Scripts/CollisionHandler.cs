using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How long before reloading level on collision death?")]
    float levelLoadDelay = 1f;

    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log(this.name + "-- crashed into --" + collision.gameObject.name);
    //     HandleDeathSequence();
    // }

    void OnTriggerEnter(Collider trigger)
    {
        Debug.Log(this.name + "** was triggered by **" + trigger.gameObject.name);
        HandleDeathSequence();
    }

    void HandleDeathSequence()
    {
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

}
