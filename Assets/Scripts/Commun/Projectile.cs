 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject fx_hit;
    
    private float speed;
    private void Start()
    {
        StartCoroutine(DelayedDeath());
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyBullets")
        {
            HitEffect();

            Destroy(other.transform.gameObject);
            Destroy(transform.gameObject);
        }
        if (other.transform.tag == "Enemies")
        {
            HitEffect();
            other.transform.GetComponent<EnemieLifes>().GetHit(1);
            Destroy(this.transform.gameObject);
        }
        if (other.transform.tag == "SpikeSpawner")
        {
            other.transform.GetComponent<SpikeSpawner>().GetHit();
            other.transform.GetComponent<EnemieLifes>().GetHit(1);
            HitEffect();
        }
        if (other.transform.tag == "Boss")
        {
            other.transform.GetComponent<BossLife>().GetHit(1);
            HitEffect();
            Destroy(this.transform.gameObject);
        }
    }
    private void HitEffect()
    {
        Instantiate(fx_hit, this.transform.position, Quaternion.identity);
    }
    private IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.transform.gameObject);
    }
}
