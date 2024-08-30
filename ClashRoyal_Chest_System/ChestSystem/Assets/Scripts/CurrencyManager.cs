using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    private int coins;
    private int gems;

    private void Awake()
    {
        instance = this;
    }
    public bool HasEnoughgems(int cost)
    {
        return gems >= cost;

    }

    public void SpendGems(int cost)
    {

        if (HasEnoughgems(cost))
        {
            gems -= cost;
        }
    }
    public void AddCoins(int amount)
    {
        coins += amount;
    }
    public void AddGems(int amount)
    {
        gems += amount;

    }
}
