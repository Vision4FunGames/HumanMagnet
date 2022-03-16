using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFallow : MonoBehaviour
{
    public Transform target;

    public float smootSpeed = 0.125f;

    public Vector3 offset;
    public Vector3 lookAtOffset;

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position =   Vector3.MoveTowards(transform.position,target.TransformPoint(offset) ,smootSpeed*Time.deltaTime);
        transform.LookAt(target.TransformPoint(lookAtOffset));
    }
}
