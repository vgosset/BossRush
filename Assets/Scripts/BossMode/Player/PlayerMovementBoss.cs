using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBoss : MonoBehaviour
{
    [SerializeField] private int dirType;

    [SerializeField] private float m_speed = 2f;
    [SerializeField] private float m_acceleration = 2f;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;

    [SerializeField] private Light dashLight;
    [SerializeField] private Transform boss;

    private Vector2 move = new Vector2();
    private Vector2 tmpMove = new Vector2();
    private Vector3 initDashPos = new Vector3();

    private Animator anim;

    private float c_acceleration;
    private float dashTimer;
    private float dashSpeedBonus;

    private bool dashOn = false;
    private bool inTransition = false;
    private Rigidbody rb;
    private PlayerAction p_action;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        p_action = GetComponent<PlayerAction>();
    }

    private void FixedUpdate()
    {
        float dt = Time.deltaTime;

        if (dashOn)
        {
            DashHandler(dt);
        }
        if (!inTransition)
        {
            Move(dt);
        }
    }
    private void DashHandler(float dt)
    {
        dashTimer -= dt;
        dashSpeedBonus = dashSpeed;
        
        if (dashTimer <= 0)
        {
            dashOn = false;
            dashLight.enabled = false;
            dashSpeedBonus = 0;
            anim.SetTrigger("DashOff");
        }
    }
    
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    public void OnSpeedUp(InputValue value)
    {
        if (!dashOn && !inTransition && !p_action.OnWave())
            SpeedUp();
    }
    private void SpeedUp()
    {
        initDashPos = transform.position;
        dashOn = true;
        anim.SetTrigger("DashOn");
        dashLight.enabled = true;

        dashTimer = dashTime;
    }
    private void Move(float dt)
    {
        DetectMoveChanges();
        RotateAroundBoss(dt);
        HandleDepth(dt);

        if (c_acceleration > 0)
        {
            c_acceleration -= Time.deltaTime * 7;
        }
    }
    private void RotateAroundBoss(float dt)
    {
        if (move.x > 0)
        {
            transform.RotateAround(boss.position, Vector3.down, dt * FinalSpeed() * Mathf.Abs(move.x));
        }
        else if (move.x < 0)
        {
            transform.RotateAround(boss.position, Vector3.up, dt * FinalSpeed() * Mathf.Abs(move.x));
        }
    }
    private void HandleDepth(float dt)
    {
        if (move.y > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, boss.position, FinalSpeed() * dt * Mathf.Abs(move.y));
        }
        else if (move.y < 0)
        {
            Vector3 dir = (transform.position - boss.position).normalized;
            transform.position += dir * dt * FinalSpeed() * Mathf.Abs(move.y);
        }
    }
    private void DetectMoveChanges()
    {
        Vector2 dif = tmpMove - move;
        if (Mathf.Abs(dif.x) >= 0.5f || Mathf.Abs(dif.y) >= 0.5f)
        {
            c_acceleration = m_acceleration;
        }
        tmpMove = move;
    }
    public void CameraTransition(int dir)
    {
        StartCoroutine(Cor_CameraTransition(dir));
    }
    private IEnumerator Cor_CameraTransition(int dir)
    {
        inTransition = true;
        dirType = dir;
        yield return new WaitForSeconds(2f);
        inTransition = false;
    }
    private float FinalSpeed()
    {
        return (m_speed + c_acceleration + dashSpeedBonus);
    }
}