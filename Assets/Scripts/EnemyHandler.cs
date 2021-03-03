using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject damageVFX;
    [SerializeField] [Tooltip("Object's starting HP.")] int hitPoints = 3;
    [SerializeField] [Tooltip("Increase to score upon non-lethal hit.")] int hitScore = 1;
    [SerializeField] [Tooltip("Increase to score upon object's destruction.")] int deathScore = 5;
    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject particle)
    {
        // Debug.Log($"{this.name} was struck by {particle.gameObject.name}!");
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints--;
        if(hitPoints < 1)
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
        vfx.transform.parent = parentGameObject.transform;
        Destroy(this.gameObject);
    }

    void DamageEnemy()
    {
        scoreBoard.ModifyScore(hitScore);
        GameObject vfx = Instantiate(damageVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
