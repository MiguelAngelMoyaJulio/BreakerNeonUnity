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
    private static float TIME_CHANGE_LEVEL = 0.5f;
    private static float EFFECT_DURATION = 0.2f;
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
                StartCoroutine(fadeEffect(1));
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
        yield return new WaitForSeconds(EFFECT_DURATION);
        effect.SetActive(false);
    }
    
    IEnumerator fadeEffect(int currenScene)
    {
        yield return new WaitForSeconds(TIME_CHANGE_LEVEL);
        SceneManager.LoadScene(currenScene);
    }
}