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
    private static int LAST_LEVEL = 7;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                SceneManager.LoadScene("LOSE-WIN");
            }
        }
    }
}