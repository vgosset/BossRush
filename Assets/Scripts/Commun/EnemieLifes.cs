using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLifes : MonoBehaviour
{
    [SerializeField] private int a_life;

    private int c_life;

    private void Start()
    {
        c_life = a_life;
    }
    public void GetHit(int amount)
    {
        c_life -= amount;
        if (c_life <= 0)
        {
            GetComponent<DeathEffect>().Die();
        }
    }
}
