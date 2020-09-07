using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject proj;
    [SerializeField] private ParticleSystem fx_fire;
    [SerializeField] private WaveAction a_wave;

    [SerializeField] private Transform mainTorus;
    [SerializeField] private Transform projPos ;

    [SerializeField] private float projSpeed = 20f;
    [SerializeField] private float rotateSpeed = 250f;
    [SerializeField] private float fireDelay = 0.3f;
    [SerializeField] private float waveDelay = 4f;

    private Projectile c_proj;
    private Animator anim;

    private float rotateRight;
    private float rotateLeft;
    private float c_rotate;
    private float fireTimer;
    private float waveTimer;
    
    private bool fireReady = true;
    private bool fireOn = false;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Reload();
    }
    private void Update()
    {
        float dt = Time.deltaTime;
        TimerHandler(dt);
    }
    private void TimerHandler(float dt)
    {
        if (waveTimer >= 0)
        {
            waveTimer -= dt;
        }
        if (fireOn && fireTimer <= 0)
        {
            if (!c_proj)
                Reload();
            Fire();
            fireTimer = fireDelay;
        }
        else if (fireOn && fireTimer >= 0)
        {
            fireTimer -= dt;
        }
    }
    private void LateUpdate()
    {
        Rotate();
    }
    public void OnRotateTorusRight(InputValue value)
    {
        float f = value.Get<float>();

        rotateRight = f;
        c_rotate = f;
        
        if (f == 0)
        {
            c_rotate = rotateLeft;
        }
    }
    public void OnRotateTorusLeft(InputValue value)
    {
        float f = value.Get<float>();

        rotateLeft = -f;
        c_rotate = -f;

        if (f == 0)
        {
            c_rotate = rotateRight;
        }
    }
    public void OnFire(InputValue value)
    {
        if (!fireOn)
        {
            fireOn = true;
        }
        else
        {
            fireOn = false;
            fireTimer = 0;
            Reload();
        }
    }
    public void OnWave(InputValue value)
    {
        if (waveTimer <= 0)
        {
            anim.SetTrigger("Wave");
            waveTimer = waveDelay;
        }
    }
    private void Fire()
    {
        GameObject tmp = Instantiate(proj, projPos.position, Quaternion.identity);
        c_proj = tmp.GetComponent<Projectile>();

        tmp.transform.rotation = Quaternion.Euler(new Vector3(0, mainTorus.eulerAngles.y-135, 0));
        tmp.transform.parent = projPos;

        fireReady = false;
        fireTimer = fireDelay;

        c_proj.transform.parent = null;
        c_proj.SetSpeed(projSpeed);
        c_proj.transform.GetChild(0).gameObject.SetActive(true);

        c_proj = null;

        fx_fire.Play();
    }
    private void Reload()
    {
        
    }
    private void Rotate()
    {
        mainTorus.Rotate(Vector3.forward, rotateSpeed * c_rotate * Time.deltaTime, Space.Self);
    }
    public void SetWaveOn()
    {
        a_wave.isActive = true;
    }
    public void SetWaveOff()
    {
        a_wave.isActive = false;
    }
    public bool OnWave()
    {
        return a_wave.isActive;
    }
}