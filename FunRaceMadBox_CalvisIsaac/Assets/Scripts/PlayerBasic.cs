using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    public float speed = 1.0f;

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f,0f,1f) * speed);
        }
        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, -1f) * speed);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * speed);
        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 0f) * speed);
        }
    }
}
