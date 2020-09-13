using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponCollider : MonoBehaviour
{
    [SerializeField] private BossState bossState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            bossState.CheckWeaponHit(other.transform.GetComponent<PlayerLifes>());
        }
    }
}
