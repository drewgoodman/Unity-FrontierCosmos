using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] [Tooltip("Increase to score upon hit.")] int deathScore = 1;
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject particle)
    {
        // Debug.Log($"{this.name} was struck by {particle.gameObject.name}!");
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        scoreBoard.ModifyScore(deathScore);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
