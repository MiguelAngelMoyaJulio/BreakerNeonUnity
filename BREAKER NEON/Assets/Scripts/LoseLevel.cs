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
    [SerializeField] GameObject effectLose;
    // [SerializeField] GameObject fadeTransition;

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
            effectLose.SetActive(true);
            StartCoroutine(effectDuration(effectLose));
            if (life.getTotalLife() <= 0)
            {
                // effectLose.SetActive(false);
                StartCoroutine(fadeEffect(1));
                SceneManager.LoadScene("LOSE-WIN");
            }
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     effectLose.SetActive(false);
    // }

    private void resetBall()
    {
        ball.resetPosition();
    }

    IEnumerator effectDuration(GameObject effect)
    {
        yield return new WaitForSeconds(0.2f);
        effect.SetActive(false);
    }
    
    IEnumerator fadeEffect(int currenScene)
    {
        // Instantiate(fadeTransition,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(currenScene);
    }
}