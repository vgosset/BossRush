using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieProj : MonoBehaviour
{
    [SerializeField] private GameObject fx_hit;

    private int damage = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerLifes>().GetHit(damage);
            Instantiate(fx_hit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    public void SetDamage(int amount)
    {
        damage = amount;
    }
}
