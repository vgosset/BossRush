using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private float rotated = 0;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        var angle = Mathf.Min(180.0f - rotated, rotateSpeed * Time.deltaTime);
        var rotation = Vector3.up * angle;

        rotated += angle;

        transform.Rotate(rotation, Space.World);
        
        if (rotated >= 180)
        {
            rotated = 0;
        }
    }
}
