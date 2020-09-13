using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private List<BossWeaponAction> weaponActionLst;
    [SerializeField] private float[] weaponDelay;

    private float weaponTimer = 3.5f;
    private bool rotateOn = true;
    private bool hasHit = false;
    private int phase_id = 0;
    private int c_WeaponDmg;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        phase_id = 0;
    }
    private void FixedUpdate()
    {
        float dt = Time.deltaTime;
        
        if (rotateOn)
        {
            RotateToPlayer(dt);
        }
        WeaponHandler(dt);
    }
    private void WeaponHandler(float dt)
    {
        if (weaponTimer > 0)
        {
            weaponTimer -= dt;
        }
        else if (weaponTimer < 0)
        {
            WeaponFire();
        }
    }
    private void WeaponFire()
    {
        int id = Random.Range(0, weaponActionLst.Count);
        
        BossWeaponAction action = weaponActionLst[id];

        c_WeaponDmg = action.damage;
        weaponTimer = weaponDelay[phase_id] + action.duration;

        anim.SetTrigger(action.animTrigger);
        hasHit = false;
    }
    private void RotateToPlayer(float dt)
    {
        Vector3 targetDir = player.position - transform.position;
        targetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), dt * rotateSpeed);
    }
    public void CheckWeaponHit(PlayerLifes l_player)
    {
        if (!hasHit)
        {
            l_player.GetHit(c_WeaponDmg);
            hasHit = true;
            Debug.Log("Hit !");
        }
    }
    public void SetRotateOn()
    {
        rotateOn = true;
    }
    public void SetRotateOff()
    {
        rotateOn = false;
    }
    public void StateChange(int n)
    {
        phase_id = n;
    }
}
