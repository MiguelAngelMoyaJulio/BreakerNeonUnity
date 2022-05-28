using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevel : MonoBehaviour
{
    private Health life;
    private Ball ball;
    private int amountDecrease = 1;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
        life = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Ball"))
        {
            life.substractLife(amountDecrease);
            Invoke(nameof(resetBall), 1f);
            if (life.getTotalLife() <= 0)
            {
                SceneManager.LoadScene("LOSE-WIN");
            }
        }
    }

    private void resetBall()
    {
        ball.resetPosition();
    }
}