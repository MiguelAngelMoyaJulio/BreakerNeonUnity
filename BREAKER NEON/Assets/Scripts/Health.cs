using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    private TextMeshProUGUI lifetText;
    private int totalLife = 15;
    private void Awake()
    {
        lifetText = GetComponent<TextMeshProUGUI>();
        lifetText.text = totalLife.ToString();
    }
    
    public int getTotalLife()
    {
        return totalLife;
    }

    public void substractLife(int amountDecrease)
    {
        totalLife = totalLife - amountDecrease;
        lifetText.text = totalLife.ToString();
    }

    public void SetHealth(int life)
    {
        this.totalLife = life;
    }
}