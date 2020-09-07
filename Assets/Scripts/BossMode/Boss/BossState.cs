using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float[] weaponDelay;

    private float weaponTimer = 3.5f;
    private bool rotateOn = true;
    private int phase_id = 0;
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
        int id = Random.Range(0, 2);

        switch (id)
        {
            case 0 :
            anim.SetTrigger("SpearClassic");
            break;
            default :
            anim.SetTrigger("HammerClassic");
            break;
        }
        weaponTimer = weaponDelay[phase_id];
    }
    private void RotateToPlayer(float dt)
    {
        Vector3 targetDir = player.position - transform.position;
        targetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), dt * rotateSpeed);
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
