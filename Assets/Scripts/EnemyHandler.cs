﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    void OnParticleCollision(GameObject particle)
    {
        // Debug.Log($"{this.name} was struck by {particle.gameObject.name}!");
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
