using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATargetBehavior : MonoBehaviour
{

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform bulletSpot;

    private UnityEngine.AI.NavMeshAgent agent;
    private bool canFire = true;
    private GameObject target;
    private float fireRateTimer;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent.speed = movementSpeed;
    }
    private void Update()
    {
        if (canFire)
            Fire();
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
            canFire = true;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);

        Vector3 targetDir = target.transform.position - transform.position;
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void Fire()
    {
        canFire = false;
        fireRateTimer = 0;
        GameObject tmp = Instantiate(bullet, bulletSpot.position, Quaternion.LookRotation(bulletSpot.rotation * -Vector3.forward));
        tmp.GetComponent<FollowProj>().SetSpeed(projectileSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerLifes>().GetHit(1);
            GetComponent<DeathEffect>().Die();
            Destroy(this.gameObject);
        }
    }
}
