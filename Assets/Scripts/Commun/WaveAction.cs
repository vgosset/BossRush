using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAction : MonoBehaviour
{
    [SerializeField] private GameObject fx_hit;

    public bool isActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.transform.tag == "EnemyBullets")
            {
                Destroy(other.transform.gameObject);
                HitEffect();
            }
            if (other.transform.tag == "Enemies")
            {
                other.transform.GetComponent<EnemieLifes>().GetHit(1);
                HitEffect();
            }
            if (other.transform.tag == "StaticObstacle")
            {
                other.transform.GetComponent<ObstacleBehavior>().HasBeenHit();
                HitEffect();
            }
            if (other.transform.tag == "SpikeSpawner")
            {
                other.transform.GetComponent<SpikeSpawner>().GetHit();
                other.transform.GetComponent<EnemieLifes>().GetHit(1);
                HitEffect();
            }
        }
    }
    private void HitEffect()
    {
        Instantiate(fx_hit, transform.position, Quaternion.identity);
    }
}
