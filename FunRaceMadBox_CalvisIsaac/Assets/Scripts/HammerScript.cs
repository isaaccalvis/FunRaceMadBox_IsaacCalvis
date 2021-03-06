﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public float speed = 1f;
    public float force = 1f;
    
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = speed;
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 1) * force);
    }
}
