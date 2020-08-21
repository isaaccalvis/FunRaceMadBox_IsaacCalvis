using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBasic : MonoBehaviour
{
    // PUBLIC
    // Player
    public float speed = 1.0f;
    public bool canMove = false;
    // Ui
    public Text scoreText;
    // Collision
    public float y_coll_mod = 1.5f;
    public float x_coll_mod = 1.5f;

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
        if (transform.position.y < -4f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 forceDirection = (transform.position - collision.gameObject.transform.position).normalized
                * collision.transform.parent.parent.GetComponent<HammerScript>().force;
            forceDirection.y = Mathf.Abs(forceDirection.y) * y_coll_mod;
            forceDirection.x = Mathf.Abs(forceDirection.x) * x_coll_mod;

            GetComponent<Rigidbody>().AddForce(forceDirection);
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
