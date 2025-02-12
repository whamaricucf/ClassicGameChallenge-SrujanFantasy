using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMultiplier : MonoBehaviour
{
    public int currentGold;
    public int droppedGold;
    private int deathGold;

    private float goldMultiplier = 1f;

    public bool hasDied;

    // Start is called before the first frame update
    void Start()
    {
        GoldLossOnDeath();
        GoldGain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoldLossOnDeath()
    {
        if (hasDied == true)
        {
            deathGold = currentGold;
            currentGold = currentGold / 2;
            hasDied = false;
        }
    }

    void GoldGain()
    {
        if (currentGold < deathGold)
        {
            goldMultiplier = 1.3f;
        }
        currentGold = (int)(currentGold + droppedGold * goldMultiplier);
        goldMultiplier = 1f;
    }
}
