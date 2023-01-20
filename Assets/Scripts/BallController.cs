using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public bool isRight;
    public float speed = 15;
    public GameObject ballPrefb;
    private GameManager gameManager;
    private Rigidbody ballRb;
    private bool isMoviment = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallMovimentHorizontal();
        PullBall();
    }

    void PullBall()
    {
        if (Input.GetMouseButtonDown(0) && isMoviment)
        {
            isMoviment = false;
            ballRb.AddForce(new Vector3(-1, 0, 0) * 300 * Time.deltaTime, ForceMode.Impulse);
            ballRb.AddForce(new Vector3(0, 1, 0) * 600 * Time.deltaTime, ForceMode.Impulse);

            ballRb.useGravity = true;
        }

        if (gameManager.restartBall)
        {
            gameManager.RestartBall(false);
        }
    }

    void BallMovimentHorizontal()
    {
        if (transform.position.z <= -2.8f)
        {
            isRight = false;
        }

        if (transform.position.z >= 2.4f)
        {
            isRight = true;
        }

        if (isMoviment)
        {
            if (isRight)
            {

                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            gameManager.RestartBall(true);
            gameManager.RespawnBall();
        }
    }
}
