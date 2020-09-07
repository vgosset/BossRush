using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpikeMissile : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    private float speed;
    private float rotateSpeed = 10;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);

        Vector3 targetDir = target.transform.position - transform.position;
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
    public void SetSpeed(float s)
    {
        agent.speed = s;
    }
}
