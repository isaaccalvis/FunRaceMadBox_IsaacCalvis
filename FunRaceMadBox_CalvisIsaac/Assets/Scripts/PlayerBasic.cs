using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasic : MonoBehaviour
{
    // PUBLIC
    public float speed = 1.0f;
    public bool canMove = false;
    public Text scoreText;

    // PRIVATE
    private int score = 0;

    // EXTERN
    public GameObject camera;
    public GameObject particles;

    private void Start()
    {
        canMove = false;
        particles.SetActive(false);
        score = 0;
    }

    void FixedUpdate()
    {
        if (canMove)
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Sensor_End")
        {
            canMove = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            particles.SetActive(true);
            particles.GetComponent<ParticleSystem>().time = 0;
            camera.GetComponent<CameraScript>().Win();
        }
        if (collision.gameObject.tag == "Sensor_WinPoint")
        {
            print("win score");
            score++;
            Destroy(collision.gameObject);
            scoreText.text = score.ToString();
        }
    }
}
