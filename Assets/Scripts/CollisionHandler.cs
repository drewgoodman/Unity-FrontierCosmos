﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;

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
        DisableGameInput();
        DestroyPlayerShip();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void DisableGameInput()
    {
        GetComponent<PlayerController>().SetLasersActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    void DestroyPlayerShip()
    {
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
    }

}
