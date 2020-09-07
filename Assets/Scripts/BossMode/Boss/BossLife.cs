using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossMode;
public class BossLife : MonoBehaviour
{
    [SerializeField] private int lifeAmount;
    private int currentLife;
    private BossState bossState;
    private void Awake()
    {
        bossState = GetComponent<BossState>();
    }
    private void Start()
    {
        currentLife = lifeAmount;
        UpdateLifeOnUi();
    }
    public void GetHit(int amount)
    {
        currentLife -= amount;
        UpdateLifeOnUi();
        CheckState();
    }
    private void UpdateLifeOnUi()
    {
        UiManager.Instance.UpdateBossLife(currentLife, lifeAmount);
    }
    private void CheckState()
    {
        if (currentLife < lifeAmount * 0.33f)
        {
            bossState.StateChange(2);
        }
        else if (currentLife < lifeAmount * 0.66f)
        {
            bossState.StateChange(1);
        }
    }
}
