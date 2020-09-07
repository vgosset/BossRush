using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int dirType;

    [SerializeField] private float m_speed = 2f;
    [SerializeField] private float m_acceleration = 2f;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;

    [SerializeField] private Light dashLight;
    [SerializeField] private Transform cameraFollow;

    private Vector2 move = new Vector2();
    private Vector2 tmpMove = new Vector2();
    private Vector3 dashDir = new Vector3();
    private Vector3 initDashPos = new Vector3();

    private Animator anim;

    private float c_acceleration;
    private float dashTimer;

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
            dashDir = DefineMoveType();
            transform.position += dashDir * Time.deltaTime * dashSpeed;
            dashTimer -= dt;

            if (dashTimer <= 0)
            {
                dashOn = false;
                dashLight.enabled = false;
                anim.SetTrigger("DashOff");
            }
        }
        else if (!inTransition)
            Move(dt);
        Debug.Log("camera pos =>" + cameraFollow.position);
        Debug.Log("this =>" + this.transform.position);
        Debug.Log("dif => " + (this.transform.position - cameraFollow.position));
    }
    private bool OutOfField(Vector3 pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + pos, Vector3.down, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position + pos, Vector3.down * hit.distance, Color.yellow);
            Debug.Log("Did Hit" + hit.transform.name);
            return false;
        }
        return true;
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
        DetectMoveChange();

        Vector3 m = DefineMoveType() * dt * (m_speed + c_acceleration);
        
        // if (!OutOfField(m))
        // {
            transform.Translate(m, Space.World);
        // }

        if (c_acceleration > 0)
        {
            c_acceleration -= Time.deltaTime * 7;
        }
    }
    private void DetectMoveChange()
    {
        Vector2 dif = tmpMove - move;
        if (Mathf.Abs(dif.x) >= 0.5f || Mathf.Abs(dif.y) >= 0.5f)
        {
            c_acceleration = m_acceleration;
        }
        tmpMove = move;
    }
    private Vector3 DefineMoveType()
    {
        Vector3 type;

        switch (dirType)
        {
            case 0:
                type = new Vector3(-move.y, 0, move.x);
            break;
            case 1:
                type = new Vector3(-move.x, 0, -move.y);
            break;
            case 2:
                type = new Vector3(move.y, 0, -move.x);
            break;
            default:
                type = new Vector3(move.x, 0, move.y);
            break;
        }
        
        return type;
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
}