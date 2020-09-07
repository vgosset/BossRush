using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody rb;

    public void SetSpeed(float speed)
    {
        rb.velocity  = transform.rotation * Vector3.forward * speed;
    }

    private void OnColliderEnter(Collision other)
    {

    }
    
}
