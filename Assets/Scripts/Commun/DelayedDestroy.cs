using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField] private float delay = 2f;

    private void Start()
    {
        Invoke("SelfDestroy", delay);
    }
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
