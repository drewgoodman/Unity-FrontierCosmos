using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    // for auto destruction of game objects instantiated for particle VFX
    [SerializeField] float timeTilDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeTilDestroy);
    }
}
