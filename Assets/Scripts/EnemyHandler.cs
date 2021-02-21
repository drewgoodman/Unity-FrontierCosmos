using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    void OnParticleCollision(GameObject particle)
    {
        Debug.Log($"{this.name} was struck by {particle.gameObject.name}!");
        Destroy(this.gameObject);
    }
}
