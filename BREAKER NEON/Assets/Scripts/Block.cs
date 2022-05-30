using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int health = 0;
    private BlockLoad blockLoad;
    [SerializeField] int scoreBlock = 0;
    private Score scoreManager;
    [SerializeField] GameObject deadEffect;
    [SerializeField] GameObject soundDead; 

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
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            scoreManager.incrementScore(scoreBlock);
            blockLoad.blocksSubstract();
            Instantiate(soundDead, transform.position,Quaternion.identity);
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