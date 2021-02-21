using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + "-- crashed into --" + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider trigger)
    {
        Debug.Log(this.name + "** was triggered by **" + trigger.gameObject.name);
    }


}
