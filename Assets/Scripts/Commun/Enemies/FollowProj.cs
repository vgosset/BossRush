using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProj : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Transform target;

    private void Awake()
    {
    }
    private void FixedUpdate()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
}
