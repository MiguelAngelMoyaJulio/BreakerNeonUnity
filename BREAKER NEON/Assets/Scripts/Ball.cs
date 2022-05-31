using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 200f;
    private Vector3 initialPosition;
    [SerializeField] GameObject soundHit;

    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        // the movement of the ball take 1 second to start
        Invoke(nameof(randomDirection), 0.5f);
    }

    private void randomDirection()
    {
        // assing random values for x and add some speed to the ball 
        Vector2 force = new Vector2(0, 0);
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        this.rb.AddForce(force.normalized * this.speed);
    }

    public void resetPosition()
    {
        transform.position = initialPosition;
        rb.velocity = new Vector2(0, 0);
        randomDirection();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(soundHit,transform.position,Quaternion.identity);
    }

    public void freezeBall()
    {
        rb.velocity = new Vector2(0, 0);
    }
}