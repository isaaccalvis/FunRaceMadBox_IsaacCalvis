using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // TIMER
    private float timer = 0.0f;
    float speed_starting = 0.1f;
    float speed_ending = 3f;

    // POINTS
    public GameObject player;
    public Transform player_point;
    public Transform end_point;

    // CAMERA PHASES
    public enum CameraPhases
    {
        NULL,
        STARTING,
        FOLLOWING,
        ENDING
    };
    CameraPhases phase = CameraPhases.NULL;

    private void Start()
    {
        timer = 0.0f;
        phase = CameraPhases.STARTING;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        switch(phase)
        {
            case CameraPhases.NULL:

                break;
            case CameraPhases.STARTING:
                if ((transform.position - player_point.position).magnitude < speed_starting * 2)
                {
                    transform.LookAt(player.transform.position);
                    transform.position = player_point.position;
                    phase = CameraPhases.FOLLOWING;
                }
                else
                {
                    transform.Translate(-(transform.position - player_point.position).normalized * speed_starting);
                }

                break;
            case CameraPhases.FOLLOWING:
                transform.LookAt(player.transform.position);
                transform.position = player_point.position;
                break;
            case CameraPhases.ENDING:

                break;
        }
    }
}
