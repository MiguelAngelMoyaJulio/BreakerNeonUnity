using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockUI : MonoBehaviour
{
    private GameObject blockLoad;
    private TextMeshProUGUI blockText;
    private int blocksLeft = 0;

    private void Awake()
    {
        blockText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        updateBloksLeft();
    }

    private void updateBloksLeft()
    {
        if (GameObject.Find("BlockLoad") != null)
        {
            blockLoad = GameObject.Find("BlockLoad");
            blocksLeft = blockLoad.GetComponent<BlockLoad>().amountBlock;
            blockText.text = blocksLeft.ToString();
        }
    }
}