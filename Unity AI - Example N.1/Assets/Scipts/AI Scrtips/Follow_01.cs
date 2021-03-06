﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_01 : MonoBehaviour
{    
    public Transform objToFollow;

    public float aiVelocity = 7.0f;
    //  World Coordinates
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;

    private void Start()
    {
        y = transform.position.y;
    }

    private void Update()
    {
        x = transform.position.x;
        z = transform.position.z;

        if (objToFollow.position.x > x)
        {
            x += aiVelocity * Time.deltaTime;
        }
        if (objToFollow.position.x < x)
        {
            x -= aiVelocity * Time.deltaTime;
        }

        if (objToFollow.position.z > z)
        {
            z += aiVelocity * Time.deltaTime;
        }
        if (objToFollow.position.z < z)
        {
            z -= aiVelocity * Time.deltaTime;
        }

        transform.position = new Vector3(x, y, z);
    }
}
