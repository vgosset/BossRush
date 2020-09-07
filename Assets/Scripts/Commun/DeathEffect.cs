using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private GameObject fx_die;

    public void Die()
    {
        Instantiate(fx_die, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
