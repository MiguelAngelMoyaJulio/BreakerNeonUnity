using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int health = 0;
    private BlockLoad blockLoad;
    private int scoreBlock = 25;
    private Score scoreManager;
    [SerializeField] GameObject deadEffect;

    private void Awake()
    {
        scoreManager = FindObjectOfType<Score>();
        blockLoad = FindObjectOfType<BlockLoad>();
    }

    private void Start()
    {
        blockLoad.countBlocks();
    }

    private void hit()
    {
        this.health--;
        if (this.health <= 0)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
            scoreManager.incrementScore(scoreBlock);
            blockLoad.blocksSubstract();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            hit();
        }
    }
}