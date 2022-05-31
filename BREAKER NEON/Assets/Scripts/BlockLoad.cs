using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BlockLoad : MonoBehaviour
{
    public int amountBlock;
    private GameManager gameManager;
    private Ball ball;
    private static int LAST_LEVEL = 7;
    private static int LOSE_WIN_LEVEL = 1;
    private static float TIME_CHANGE_LEVEL = 1f;

    [SerializeField] GameObject fadeTransition;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        noBlocks();
    }

    public void countBlocks()
    {
        amountBlock++;
    }

    public void blocksSubstract()
    {
        amountBlock--;
    }

    public void noBlocks()
    {
        if (amountBlock <= 0)
        {
            int nextLevel = gameManager.GetActualLevel();
            if (nextLevel < LAST_LEVEL)
            {
                nextLevel++;
                StartCoroutine(fadeEffect(nextLevel));
                // SceneManager.LoadScene(nextLevel);
            }
            else
            {
                StartCoroutine(fadeEffect(LOSE_WIN_LEVEL));
                // SceneManager.LoadScene("LOSE-WIN");
            }
        }
    }

    IEnumerator fadeEffect(int currenScene)
    {
        ball.freezeBall();
        // Instantiate(fadeTransition,transform.position,Quaternion.identity);
        fadeTransition.GetComponent<Animator>().SetBool("fade", true);
        yield return new WaitForSeconds(TIME_CHANGE_LEVEL);
        SceneManager.LoadScene(currenScene);
        fadeTransition.GetComponent<Animator>().SetBool("fade", false);
    }
}