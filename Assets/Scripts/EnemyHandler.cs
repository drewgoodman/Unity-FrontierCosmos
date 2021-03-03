﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject damageVFX;
    [SerializeField] Transform parent;
    [SerializeField] [Tooltip("Object's starting HP.")] int hitPoints = 3;
    [SerializeField] [Tooltip("Increase to score upon hit.")] int hitScore = 1;
    [SerializeField] [Tooltip("Bonus increase to score upon object's destruction.")] int deathScore = 5;
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject particle)
    {
        // Debug.Log($"{this.name} was struck by {particle.gameObject.name}!");
        ProcessHit();
    }

    void ProcessHit()
    {
        scoreBoard.ModifyScore(hitScore);
        hitPoints -= 1;
        if(hitPoints == 0)
        {
            KillEnemy();
        }
        else
        {
            DamageEnemy();
        }
    }

    void KillEnemy()
    {
        scoreBoard.ModifyScore(deathScore);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

    void DamageEnemy()
    {
        GameObject vfx = Instantiate(damageVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }
}
